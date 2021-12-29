namespace WhatsNew.New.Net8_10;

public class Lambdas
{
    private static Func<int, int, int> addMethod => (int a, int b) => a + b;

    public static int? PaseInt(string text)
    {
        int number;
        var func = (string? text) => int.TryParse(text, out number) ? number : (int?)null;
        return func(text);
    }

    public void methods()
    {
        Console.WriteLine(addMethod(12, 3));
    }
}

