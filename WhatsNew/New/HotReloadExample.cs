namespace WhatsNew.New;

internal class HotReloadExample : IDisposable
{
    public bool bugged { get; set; } = true;

    public void Dispose() => bugged = false;

    public async Task Looped()
    {
        int iBugLoop = 1;
        while (bugged)
        {
            bugged = FixMethod();
            await Task.Delay(2000);
            Console.WriteLine($"Executed method looped {iBugLoop++} times.");      
            
            if (!bugged)
            {
                Console.WriteLine("Thanks for fixing me");
            }
        }
    }

    public bool FixMethod()
    {
        return true;
    }



}
