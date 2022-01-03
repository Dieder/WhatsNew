namespace WhatsNew.New.Net8_10;

public class Lambdas
{
    private static Func<int, int, int> addMethod => (int a, int b) => a + b;

    public static int AddMethodNotLambda(int a, int b)
    {
        var addMethodLambda = (int a, int b) => a + b;
        return addMethodLambda(a, b);
    }

    public static int? PaseInt(string text)
    {
        int number;
        var func = (string? text) => int.TryParse(text, out number) ? number : (int?)null; //int? is needed for the compiler to determine the return type
        return func(text);
    }

    public void methods()
    {
        Console.WriteLine(addMethod(12, 3));
    }
}

