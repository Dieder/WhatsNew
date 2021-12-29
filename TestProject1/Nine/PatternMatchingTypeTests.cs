using Xunit.Abstractions;

namespace TestProject1.Nine;

public class PatternMatchingTypeTests
{
    private readonly TestOutput output;

    public PatternMatchingTypeTests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }


    [Fact]
    public void TestPatternMatchingTypes()
    {
        PatternMarchingType patternMatchinType = new(output);

        var employee = new Employee { FirstName = "Ella", LastName = "Johnson", Addressing = "Miss." };
        patternMatchinType.GetVistorType(employee);

        var visitor = new Visitor { FirstName = "Marc", LastName = "Smith" };
        patternMatchinType.GetVistorType(visitor);
    }
}
