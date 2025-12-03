// See https://aka.ms/new-console-template for more information
using Seido.Utilities.SeedGenerator;
using _15_polymorphism.Models;

Console.WriteLine("Hello Polymorphism!");

var seeder = new SeedGenerator();
var animal = new Animal().Seed(seeder);
System.Console.WriteLine(animal);

var animals = seeder.ItemsToList<Animal>(5);
foreach (var a in animals)
{
    System.Console.WriteLine(a);
}