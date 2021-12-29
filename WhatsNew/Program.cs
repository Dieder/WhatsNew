// See https://aka.ms/new-console-template for more information
using WhatsNew.New.Net8_10;

Console.WriteLine("Examples");

Console.WriteLine(string.Empty.PadRight(40, '-'));
Console.WriteLine("Switch action");
Console.WriteLine(string.Empty.PadRight(40, '-'));
var myKnownColor = KnownColors.Green;
Console.BackgroundColor = SwitchExample.GetKnownColor(myKnownColor);
Console.WriteLine("Known Color is set");
Console.BackgroundColor = ConsoleColor.Black;

var personX = new PersonRecord("Dieder", "Timmerman");
Console.WriteLine(CallerExpression.EnsureArgumentIsNotNull(personX.Address));