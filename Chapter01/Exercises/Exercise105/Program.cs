using System;

class Program
{
    static void Main(string[] args)
    {
        var aGolden = new GoldenRetriever() { Name = "Aspen", Fam = "Ok" };
        var anotherGolden = new GoldenRetriever() { Name = "Aspen", Fam="Ok" };

        Console.WriteLine(aGolden.Equals(anotherGolden) ? "Goldens are all equal anyway, even more with the same name!" : "Well, looks like they're not the same");

        var aBorder = new BorderCollie() { Name = "Aspen" };
        var anotherBorder = new BorderCollie() { Name = "Aspen" };

        Console.WriteLine(aBorder.Equals(anotherBorder) ? "Borders are all equal anyway, even more with the same name!" : "Well, looks like these borders not the same");

        var aBernaise = new Bearnaise() { Name = "Aspen" };
        var anotherBernaise = new Bearnaise() { Name = "Aspen" };

        Console.WriteLine(aBernaise.Equals(anotherBernaise) ? "Bearnaises are all equal anyway, even more with the same name!" : "Well, looks like they're not the same");
    }
}

struct GoldenRetriever
{
    public string Name { get; set; }
    public string Fam { get; set; }
}

class BorderCollie
{
    public string Name { get; set; }
}

class Bearnaise
{
    public string Name { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is Bearnaise borderCollie && obj != null)
        {
            return this.Name == borderCollie.Name;
        }

        return false;
    }
}
