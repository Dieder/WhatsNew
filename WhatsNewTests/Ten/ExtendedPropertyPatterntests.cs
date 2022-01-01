using Xunit.Abstractions;

namespace TestProject1.Ten;

public class ExtendedPropertyPatterntests
{
    private readonly TestOutput output;

    public ExtendedPropertyPatterntests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }

    [Fact]
    public void ExtendedPropertyPattern()
    {
        
        var entranceCheckList = Organisation.CreateCheckList();

        output.WriteLine("The following male persons are known:");
        foreach (var visitor in entranceCheckList)
        {
            if (visitor is Employee { Addressing: "Mr" })
            {
                output.WriteLine(visitor.FullName);
            }
        }

        output.WriteLine("The following persons are working in Leusden:");
        foreach (var visitor in entranceCheckList)
        {             
            if (visitor is Employee { WorkAddress.City: "Leusden" })
            {
                output.WriteLine(visitor.FullName);                
            }
        }
    }
}