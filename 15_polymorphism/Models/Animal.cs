using System;
using Seido.Utilities.SeedGenerator;
namespace _15_polymorphism.Models;

public enum NordicAnimalKind { Moose, Wolf, Deer, Bear, Fox}
public enum AfricanAnimalKind { Aligator, Elephant, Lion, Donkey, Monkey}
public enum HunterBirdKind {Eagle, Hawk, Owl, Falcon}

public enum AnimalMood { Happy, Sleepy, Sad, Hungry, Lazy, Quick, Slow }
public class Animal: ISeed<Animal>
{
	public AnimalMood Mood { get; set; }
	public int Age { get; set; }
	public string Name { get; set; }

	public override string ToString() => $"{Name} the {Mood} {Age}yr";
    public virtual string MakeSound() => "unknown sound";
	
	public bool Seeded {get; set;} = false;
	public Animal Seed(SeedGenerator _seeder)
	{
		Mood = _seeder.FromEnum<AnimalMood>();
		Age = _seeder.Next(0, 10);
		Name = _seeder.PetName;
		Seeded = true;
		return this;
	}
	public Animal() { }
	public Animal(Animal org)
	{
		Mood = org.Mood;
		Age = org.Age;
		Name = org.Name;
	}
}

public class NordicAnimal: Animal, ISeed<NordicAnimal>
{
    public NordicAnimalKind Kind { get; set; }

    public bool canSwim { get; set; }

	public override string ToString() => $"{base.ToString()} of kind {Kind} who {(canSwim ? "can" : "can not" )} swim";

    public override string MakeSound()
    {
		return Kind switch
		{
			NordicAnimalKind.Wolf => "Howl",
			NordicAnimalKind.Bear => "Roar",
			NordicAnimalKind.Moose => "Bellow!",
			_ => "Animal sound"
		};
    }

    //copy constructor that calls the base copy constructor

	public NordicAnimal(NordicAnimal org) : base(org)
	{
		Kind = org.Kind;
		canSwim = org.canSwim;
    }
    public NordicAnimal()
    {
        
    }
    public new NordicAnimal Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<NordicAnimalKind>();
		canSwim = _seeder.Bool;
		return this;
	}
}

public class AfricanAnimal: Animal, ISeed<AfricanAnimal>
{
    public AfricanAnimalKind Kind { get; set; }
    public decimal WeightKg { get; set; }

	public override string ToString() => $"{Name} the {Mood} {Age}yr {Kind} who weighs {WeightKg} kg";

    public override string MakeSound()
    {
		return Kind switch
		{
			AfricanAnimalKind.Lion => "Roar!",
			AfricanAnimalKind.Elephant => "Trumpet!",
			AfricanAnimalKind.Monkey => "Screech",
			_ => "Animal sound"
		};
    }

    //copy constructor that calls the base copy constructor

	public AfricanAnimal(AfricanAnimal org) : base(org)
	{
		Kind = org.Kind;
		WeightKg = org.WeightKg;
    }

	public AfricanAnimal()
	{

    }

	public new AfricanAnimal Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		Kind = _seeder.FromEnum<AfricanAnimalKind>();
		WeightKg = _seeder.Next(50, 1000);
        return this;
    }
}
public class HunterBird: Animal, ISeed<HunterBird>
{
    public HunterBirdKind Kind { get; set; }
    public int WingspanCm { get; set; }
    public bool CanHuntAtNight { get; set; }

	public override string ToString() => $"{Name} the {Mood} {Age}yr, wingspan:{WingspanCm}cm, nighthunter: {(CanHuntAtNight ? "can hunt" : "can't hunt")}";

    public override string MakeSound()
    {
		return "Screech!";
    }
    public HunterBird(HunterBird org) : base(org)
    {
		Kind = org.Kind;
		WingspanCm = org.WingspanCm;
		CanHuntAtNight = org.CanHuntAtNight;
        
    }
    public HunterBird()
    {

    }
	public HunterBird Hunt()
	{
		Mood = AnimalMood.Quick;
        Console.WriteLine($"The kind{Kind}hunts and is quick!");
        return this;
	}
    public HunterBird Fly()
    {
        Mood = AnimalMood.Happy;
        Console.WriteLine($"The kind{Kind}flies and is happy!");
        return this;
    }
    public HunterBird Rest()
    {
        Mood = AnimalMood.Sleepy;
        Console.WriteLine($"The kind {Kind}rests and is sleepy!" );
        return this;
    }
    public new HunterBird Seed(SeedGenerator _seeder)
    {
        base.Seed(_seeder);
		Kind = _seeder.FromEnum<HunterBirdKind>();
		WingspanCm = _seeder.Next(50, 250);
		CanHuntAtNight = _seeder.Bool;
        return this;
    }

}


