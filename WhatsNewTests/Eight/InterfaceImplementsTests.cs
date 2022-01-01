using Xunit.Abstractions;

namespace TestProject1;

public class InterfaceImplementsTests
{

    private readonly TestOutput output;
    public InterfaceImplementsTests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }

    [Fact]
    public void CreateEmployees()
    {
        
        output.WriteLine("The following persons are known:");
        var entranceCheckList = Organisation.CreateCheckList();

        foreach (var person in entranceCheckList)
        {
            var totalDiscount = string.Format("{0:p}", person.GetDiscount());
            output.WriteLine(person.FullName + $" has got a discount of {totalDiscount}%.");
        }
    }
}
