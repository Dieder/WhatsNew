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

        output.WriteLine("Test with number > 20");
        patternMatchingCase.TestAnObject(21); //n

        output.WriteLine("Test with car object");
        var carObject = new Car { Wheels = 4 };
        patternMatchingCase.TestAnObject(carObject);

        output.WriteLine("Test with number equals 10");
        patternMatchingCase.TestAnObject(10); //J

        output.WriteLine("Test with null");
        patternMatchingCase.TestAnObject(null);
    }

}
