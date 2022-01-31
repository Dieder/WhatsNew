using Xunit.Abstractions;

namespace TestProject1.Nine;

public class RecordTests
{
    private readonly TestOutput output;

    public RecordTests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }

    [Fact]
    public void AreTheyTheSame()
    {
        // using three paramaters
        var nienke = new PersonRecord("Nienke", "Waal", "De");

        // Peter == Peter 2
        var peter1 = new PersonRecord("Peter", "Pan");
        var peter2 = new PersonRecord("Peter", "Pan");

        if (peter1 == peter2)
        {
            output.WriteLine("The peters are same");
        }

        // Tarzan and jane are married.
        var tarzan = new PersonRecord("Tarzan", "Porter");
        var jane = tarzan with { FirstName = "Jane" };

        if (jane != tarzan)
        {
            output.WriteLine("Tarzan is married with Jane and they are different.");
        }

        // Defined by constructor and proeprties
        var personX = new PersonRecord("Dieder", "Timmerman") { WorkYears = 4 };

        // Defined by attributes only
        Address adres = new Address
        {
            HouseNumber = 36,
            Street = "LeusderEnd",
            City = "Leusden",
            Country = "Netherlands",
            Zipcode = "3832RC"
        };
         

        personX.Address = adres;

        output.WriteLine($"{personX.LastName} has worked for { personX.WorkYears } in {personX.Address.City}.");
    }
}
