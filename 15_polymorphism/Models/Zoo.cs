using Seido.Utilities.SeedGenerator;
namespace _15_polymorphism.Models;
public class Zoo
{
    public List<Animal> ListOfAnimal { get; set; } = new List<Animal>();
    public string Name { get; set; }

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

