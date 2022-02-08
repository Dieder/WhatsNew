using TestProject1;
using Xunit.Abstractions;

namespace WhantsNewTests.Ten;

public class DateOrTimeOnlyTests
{
    private readonly TestOutput output;

    public DateOrTimeOnlyTests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }
    
    [Fact]
    public void ShowIt()
    {
        DateOnly onlyDate = new(2022, 2, 8);
        output.WriteLine(onlyDate.ToLongDateString());
        TimeOnly time = new(18, 15);
        output.WriteLine(time.ToShortTimeString());

    }
}

