// See https://aka.ms/new-console-template for more information
using Seido.Utilities.SeedGenerator;
using _15_polymorphism.Models;

internal class Program
{
    private static void Main(string[] args)
    {

        var seeder = new SeedGenerator();
        var animal = new Animal().Seed(seeder);
        Console.WriteLine(animal);

        var animals = seeder.ItemsToList<Animal>(5);
        foreach (var a in animals)
        {
            Console.WriteLine(a);
        }

        var nordicAnimal = new NordicAnimal().Seed(seeder);
        Console.WriteLine(nordicAnimal);

        var africanAnimals = new AfricanAnimal().Seed(seeder);
        Console.WriteLine(africanAnimals);

        var hunterBird = new HunterBird().Seed(seeder);
        Console.WriteLine(hunterBird);

        hunterBird.Hunt().Fly().Rest();

        var zoo = new Zoo() { Name = "My Awesome Zoo" };

        zoo.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(5));
        zoo.ListOfAnimal.AddRange(seeder.ItemsToList<AfricanAnimal>(10));
        zoo.ListOfAnimal.AddRange(seeder.ItemsToList<HunterBird>(10));

        zoo.ToString();
        Console.WriteLine();
        foreach (var a in zoo.ListOfAnimal)
        {
            Console.WriteLine($"{a.ToString()} says {a.MakeSound()}");
        }

        var zoo1 = new Zoo()
        {
            ListOfAnimal = new List<Animal>()
            {
                
                new NordicAnimal().Seed(seeder),
                new AfricanAnimal().Seed(seeder),
                new HunterBird().Seed(seeder),
            }

        };

        Console.WriteLine(zoo1.ToString());
        zoo1.ReseedAllAnimals(seeder);
        Console.WriteLine(zoo1.ToString());



    }
}