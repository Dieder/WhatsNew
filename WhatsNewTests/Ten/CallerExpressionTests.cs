

namespace TestProject1.Ten;

public class CallerExpressionTests
{
    private readonly TestOutput output;

    public CallerExpressionTests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }


    [Fact]
    public void TestCallerExpressionTests()
    {
        var personX = new PersonRecord("Dieder", "Timmerman");

        Assert.Throws<ArgumentNullException>( () => ArgumentNullException.ThrowIfNull(personX.Address));

        var ex = Assert.Throws<ArgumentNullException>(() => CallerExpression.EnsureArgumentIsNotNull(personX.Address));
        output.WriteLine(ex.Message);
    }
}
