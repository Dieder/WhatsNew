using Xunit.Abstractions;

namespace TestProject1;

public class TestOutput : IOutput
{
    private readonly ITestOutputHelper output;
    public TestOutput(ITestOutputHelper outputHelper)
    {
        this.output = outputHelper;
    }

    public void WriteLine(string message) => output.WriteLine(message);
    public void WriteLine(string format, params object[] args) => output.WriteLine(format, args);
}
