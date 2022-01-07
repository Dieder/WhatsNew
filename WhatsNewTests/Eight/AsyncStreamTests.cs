using Xunit.Abstractions;

namespace TestProject1;

public class AsyncStreamTests
{
    private readonly TestOutput output;
    public AsyncStreamTests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }


    [Fact]
    public async Task GetResultFromStream()
    {
        var streamWeb = new AsyncStreams();
        var data = await streamWeb.GetResultsAsync();

        foreach (string item in data)
        {
            output.WriteLine(item);
        }
    }
}
