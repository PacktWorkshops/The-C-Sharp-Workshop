using System;
using System.Linq;

var aGolden = new GoldenRetriever() { Name = "Aspen" };
var anotherGolden = new GoldenRetriever() { Name = "Aspen" };

var aBorder = new BorderCollie() { Name = "Aspen" };
var anotherBorder = new BorderCollie() { Name = "Aspen" };

var aBernaise = new Bearnaise() { Name = "Aspen" };
var anotherBernaise = new Bearnaise() { Name = "Aspen" };

var goldenComparison = aGolden.Equals(anotherGolden) ? "These Golden Retrievers have the same name." : "These Goldens have different names.";

var borderComparison = aBorder.Equals(anotherBorder) ? "These Border Collies have the same name." : "These Border Collies have different names.";

var bernaiseComparison = aBernaise.Equals(anotherBernaise) ? "These Bernaises have the same name." : "These Bernaises have different names.";

Console.WriteLine(goldenComparison);

Console.WriteLine(borderComparison);

Console.WriteLine(bernaiseComparison);

struct GoldenRetriever
{
    public string Name { get; set; }
}

class BorderCollie
{
    public string Name { get; set; }
}

class Bearnaise
{
    public string Name { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Bearnaise borderCollie && obj != null)
        {
            return this.Name == borderCollie.Name;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}