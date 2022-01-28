// See https://aka.ms/new-console-template for more information
using WhatsNew.New;
using WhatsNew.New.Net8_10;

HotReloadExample example = new HotReloadExample();

Console.WriteLine("Examples");

Console.WriteLine(string.Empty.PadRight(40, '-'));
Console.WriteLine("Switch action");
Console.WriteLine(string.Empty.PadRight(40, '-'));
var myKnownColor = KnownColors.Green; // hot reload by changing in GetKnownColor (example)
Console.BackgroundColor = SwitchExample.GetKnownColor(myKnownColor);
Console.WriteLine("Known Color is set");
Console.BackgroundColor = ConsoleColor.Black;

try
{
    var personX = new PersonRecord("Dieder", "Timmerman");
    Console.WriteLine(CallerExpression.EnsureArgumentIsNotNull(personX.Address));
}
catch(ArgumentNullException aex)
{
    Console.WriteLine($"catched argument null with {aex.Message}");
}

example.Looped();

if (example.bugged)
{
    Console.WriteLine("Fix me and press then enter");
    Console.ReadLine();
}
else
{
    Console.WriteLine("Press any key");
    Console.ReadKey();
}