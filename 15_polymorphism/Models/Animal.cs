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
    public new NordicAnimal Seed(SeedGenerator _seeder)
	{
		base.Seed(_seeder);
		return this;
	}
}


