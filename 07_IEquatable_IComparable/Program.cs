using Seido.Utilities.SeedGenerator;

namespace _07_IEquatable_IComparable;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("07_IEquatable_IComparable");
        var rnd = new SeedGenerator();
        var p1 = new Pearl(rnd);
        Console.WriteLine(p1);

        var p2 = new Pearl(rnd);
        Console.WriteLine(p2.GetHashCode());
        Console.WriteLine(p2);

        var p2_copy = new Pearl(p2);
        Console.WriteLine(p2_copy.GetHashCode());

        Console.WriteLine(p2_copy.Equals(p2));

        Console.WriteLine(p2_copy == p2);

        var n1 = new Necklace(10, "my necklace");
        //n1.ListOfPearls.Sort();
        Console.WriteLine(n1);

        var n2 = new Necklace(10, "my necklace");
        //n2.ListOfPearls.Sort();
        Console.WriteLine(n2);

        Console.WriteLine(n1.Equals(n2));

        var n3 = new Necklace(n2);

         n3.ListOfPearls[0].Size = 50;
        //n3.ListOfPearls[0] = new Pearl(rnd);
        Console.WriteLine(n2.ListOfPearls[0]);
        Console.WriteLine(n3.ListOfPearls[0]);

        Console.WriteLine(n2.Equals(n3));

    }
}

//Exercise:
// 1. Implementera IEquatable på Pearl
// 2. Skapa två instanser av Pearl och testa om de är lika. Tips, tänk på att
//    har en copy constructor i Pearl som enkelt skapar en kopia av instansen
// 3. Implementera operator == och != overload i Pearl och använd dessa i
//    jämförelsen
// 4. Implementera IComparable på Pearl, skapa ett halsband med 10 pärlor.
//    och sortera halsbandet först efter pärlornas storlek och sedan form 
// 5. Implementera IEqutable på Necklace
// 6. Skapa en copy constructor i Necklace
// 7. Skapa två instanser av Necklace och testa om de är lika. 

// 8. Ni som är snabba gör 1 -7  med Wine och wineCellar.
//    sortera vinerna efter distrikt och sedan pris.


