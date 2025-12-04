using Seido.Utilities.SeedGenerator;
namespace _15_polymorphism.Models;
public class Zoo
{
    public List<Animal> ListOfAnimal { get; set; } = new List<Animal>();
    public string Name { get; set; }

    public Zoo(Zoo original)
    {
        Name = original.Name;
        ListOfAnimal = new List<Animal>();

        // Deep copy: create new animal instances using their respective copy constructors
        foreach (var animal in original.ListOfAnimal)
        {
            Animal newAnimal = animal switch
            {
                NordicAnimal nordic => new NordicAnimal(nordic),    // Calls NordicAnimal copy constructor
                AfricanAnimal african => new AfricanAnimal(african),  // Calls AfricanAnimal copy constructor
                HunterBird bird => new HunterBird(bird),             // Calls HunterBird copy constructor
                _ => new Animal(animal)                              // Calls Animal copy constructor
            };
            ListOfAnimal.Add(newAnimal);
        }
    }

    public Zoo()
    {
    }

    public override string ToString()
    {
        string sRet = $"\nAnimals in Zoo {Name}:";
        foreach (var item in ListOfAnimal)
        {
            sRet += $"\n{item}";
        }
        return sRet;
    }

    public void ReseedAllAnimals(SeedGenerator seeder)
    {
        foreach (var animal in ListOfAnimal)
        { 
            animal.Seed(seeder);
        }
    }
}

