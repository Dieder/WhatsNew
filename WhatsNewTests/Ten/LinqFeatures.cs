using System.Linq;
using TestProject1;
using Xunit.Abstractions;

namespace WhantsNewTests.Ten;

public class LinqFeatures
{
    private string[] pizaSizes = new string[] { "Small", "Medium", "Large", "Extra Large" };
    private int[] pizzaSlices = new int[] { 4, 8, 12, 20 };
    private string[] pizzaKind = new string[] { "4 Fromages", "Hawai", "Peperoni", "Tonno" };

    private class PizzaChoice
    {
        public string? Size { get; init; }
        public string? Kind { get; init; }
        public int? Slize { get; init; }
        public override string ToString()
        {
            return $"{Kind} {Size} (slices {Slize})";
        }
    }

    private readonly TestOutput output;

    public LinqFeatures(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }

    [Fact]
    public void SliceSizes()
    {
        var smallLargeChoices = pizaSizes.ToList().Chunk(2).ToList();
        output.WriteLine("Small choices:" + string.Join(',', smallLargeChoices.First()));
        output.WriteLine("Large choices:" + string.Join(',', smallLargeChoices.Last()));
    }

    [Fact]
    public void ZipPizza()
    {
        var choices = pizzaKind.ToList().Zip(pizaSizes, pizzaSlices).Select(tuple => new PizzaChoice { Kind = tuple.First, Size = tuple.Second, Slize = tuple.Third });

        foreach (var choice in choices)
        {
            output.WriteLine($"Pizza is a {choice}");
        }
    }

    [Fact]
    public void MinMax()
    {
        var choices = pizzaKind.ToList().Zip(pizaSizes, pizzaSlices).Select(tuple => new PizzaChoice { Kind = tuple.First, Size = tuple.Second, Slize = tuple.Third });

        var minimumSlizesPizza = choices.MinBy(f => f.Slize);
        var maximumSlizesPizza = choices.MaxBy(f => f.Slize);

        output.WriteLine($"Minimum slize pizza: {minimumSlizesPizza}. Maximum slizes pizza: {maximumSlizesPizza}  ");
    }

    [Fact]
    public void PagedResults()
    {
        var choices = pizaSizes.CartesianProduct(pizzaKind, pizzaSlices).Select(tuple => new PizzaChoice { Size = tuple.Item1, Kind = tuple.Item2, Slize = tuple.Item3 });

        Range r = new Range(2, 4); //index 2 till index 4
        var resultOfRange = choices.Take(r);
        output.WriteLine($"Result of ranged take (2..4): {string.Join(",", resultOfRange.Select(r => r.ToString())) } ");

        // Is same as
        var resultItem3And4 = choices.Take(2..4);
        output.WriteLine($"Result of ranged take (2..4) with range param: {string.Join(",", resultItem3And4.Select(r => r.ToString())) } ");

        int startAt = 5;
        int pageSize = 3;
        Range pageRange = new Range(startAt, startAt + pageSize);
        var pagedChoices = choices.Take(pageRange);
        output.WriteLine($"paged range ({pagedChoices.Count()}): {string.Join(",", pagedChoices.Select(r => r.ToString())) } ");


    }
}
