using System;
using Seido.Utilities.SeedGenerator;

namespace _05_Wines_Interfaces
{
    public enum GrapeType { Reissling, Tempranillo, Chardonay, Shiraz, CabernetSavignoin, Syrah }
    public enum WineType { Red, White, Rose }
    public enum Country { Germany, France, Spain }

    public interface IWine
	{
        /// <summary>
        /// Name of the wine
        /// </summary>
        public string Name { get; init; }

        public Country Country { get; init; }
        public WineType WineType { get; init; }
        public GrapeType GrapeType { get; init; }

        public decimal Price { get; init; }

        public IWine Seed(SeedGenerator rnd);
    }
}

