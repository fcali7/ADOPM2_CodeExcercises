using System;
using Seido.Utilities.SeedGenerator;

namespace _05_Wines_Interfaces
{

    public class WineAsClass : IWine
    {
        public string Name { get; init; }
        public Country Country { get; init; }
        public WineType WineType { get; init; }
        public GrapeType GrapeType { get; init; }
        public decimal Price { get; init; }

        public IWine Seed(SeedGenerator rnd)
        {
            var Wr = new WineAsRecord(
                rnd.FromString("hennesy, vodka, tequila"),
                rnd.FromEnum<Country>(),
                rnd.FromEnum<WineType>(),
                rnd.FromEnum<GrapeType>(),
                rnd.NextDecimal(50, 1000)
            );
            return Wr;
        }

        // Add ToString override for better display
        public override string ToString()
        {
            return $"Wine{Name} from {Country} is {WineType} and made from {GrapeType} and the price is {Price:C} Sek" ;
        }
    }


    public struct WineAsStruct : IWine
    {
        public string Name { get; init; }
        public Country Country { get; init; }
        public WineType WineType { get; init; }
        public GrapeType GrapeType { get; init; }
        public decimal Price { get; init; }

        public IWine Seed(SeedGenerator rnd)
        {
            var Wr = new WineAsRecord(
                rnd.FromString("hennesy, vodka, tequila"),
                rnd.FromEnum<Country>(),
                rnd.FromEnum<WineType>(),
                rnd.FromEnum<GrapeType>(),
                rnd.NextDecimal(50, 1000)
            );
            return Wr;
        }
        public override string ToString()
        {
            return $"Wine{Name} from {Country} is {WineType} and made from {GrapeType} and the price is {Price:C} Sek";
        }

    }
    
    public record WineAsRecord (string Name, Country Country, WineType WineType, GrapeType GrapeType, decimal Price) : IWine
    {

        public IWine Seed(SeedGenerator rnd)
        {
            var Wr = new WineAsRecord(
                rnd.FromString("hennesy, vodka, tequila"),
                rnd.FromEnum<Country>(),
                rnd.FromEnum<WineType>(),
                rnd.FromEnum<GrapeType>(),
                rnd.NextDecimal(50, 1000)
            );
            return Wr;
        }
        public override string ToString()
        {
            return $"Wine{Name} from {Country} is {WineType} and made from {GrapeType} and the price is {Price:C} Sek";
        }
    }
}

