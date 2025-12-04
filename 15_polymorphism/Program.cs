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

        var originalZoo = new Zoo() { Name = "City Zoo" };

        originalZoo.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(5));

        var shallowCopiedZoo = new Zoo(originalZoo);

        shallowCopiedZoo.Name = "Shallow Copied Zoo";

        shallowCopiedZoo.ListOfAnimal.AddRange(seeder.ItemsToList<AfricanAnimal>(2));
        Console.WriteLine();

        Console.WriteLine("Original zoo name: " + " " + originalZoo.Name);
        Console.WriteLine("Original zoo animal count: " + originalZoo.ListOfAnimal.Count);

        Console.WriteLine("Shallow copied zoo name: " + " " + shallowCopiedZoo.Name);
        Console.WriteLine("Shallow copied zoo animal count: " + shallowCopiedZoo.ListOfAnimal.Count);


        var originalZoo1 = new Zoo() { Name = "National Zoo" };

        originalZoo1.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(5));

        var shallowCopiedZoo1 = new Zoo(originalZoo1);

        shallowCopiedZoo1.Name = "shallow copy zoo1";
        shallowCopiedZoo1.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(2));
        shallowCopiedZoo1.ListOfAnimal[0].Name = "Modify animal name";

        Console.WriteLine(originalZoo1.ToString());
        Console.WriteLine("animal count: " + originalZoo1.ListOfAnimal.Count);
        Console.WriteLine(shallowCopiedZoo1.ToString());
        Console.WriteLine("animal count: " + shallowCopiedZoo1.ListOfAnimal.Count);


        var originalzoo2 = new Zoo() { Name = "city zoo" };

        originalzoo2.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(5));

        var deepcopy = new Zoo(originalzoo2);
        deepcopy.Name = "Deep copied zoo";
        deepcopy.ListOfAnimal.AddRange(seeder.ItemsToList<NordicAnimal>(2));
        deepcopy.ListOfAnimal[0].Name = "deep copy animal";
        deepcopy.ListOfAnimal[0].Age = 99;

        Console.WriteLine(originalzoo2.ToString());
        Console.WriteLine("Animal count: " + originalzoo2.ListOfAnimal.Count);
        Console.WriteLine(deepcopy.ToString());
        Console.WriteLine("Animal count: " + deepcopy.ListOfAnimal.Count);




    }
}