using Xunit.Abstractions;

namespace TestProject1;

public class PatterMatchingCaseTests
{
    private readonly TestOutput output;

    public PatterMatchingCaseTests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }

    [Fact]
    public void PatenMatchTestTypes()
    {
        PatternMatchingCase patternMatchingCase = new(output);
        var carObject = new Car { Wheels = 4 };

        output.WriteLine("Test with number > 20");
        patternMatchingCase.TestMyI(21); //n

        output.WriteLine("Test with car object");
        patternMatchingCase.TestMyI(carObject);

        output.WriteLine("Test with number equeals20");
        patternMatchingCase.TestMyI(10); //J

        output.WriteLine("Test with null");
        patternMatchingCase.TestMyI(null);
    }

}
