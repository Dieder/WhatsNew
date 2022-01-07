
namespace WhatsNew.New.Net8_10;

public class PatternMatchingCase
{
    private readonly IOutput output;
    public PatternMatchingCase(IOutput output)
    {
        this.output = output;
    }

    public void TestMyI(object i)
    {

        switch (i)
        {
            case int n when n > (int)20:
                output.WriteLine("I is integer and greater than n");
                break;
            case Car c2:
                output.WriteLine($"I of assignable from car with property nr of wheels {c2.Wheels} ");
                break;
            case null:
                output.WriteLine("Value is null");
                break;
            case var j when (j.Equals(10)):
                output.WriteLine("Yes, this variable equals int 10");
                break;
            default:
                break;
        }
    }
}

public record Car { public int Wheels { get; set; } }
