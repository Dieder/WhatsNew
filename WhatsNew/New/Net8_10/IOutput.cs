
namespace WhatsNew.New.Net8_10;

public interface IOutput 
{
    void WriteLine(string message);

    void WriteLine(string format, params object[] args);
}
