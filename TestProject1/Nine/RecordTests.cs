using Xunit.Abstractions;

namespace TestProject1.Nine;

public  class RecordTests
{
    private readonly TestOutput output;

    public RecordTests(ITestOutputHelper outputHelper)
    {
        output = new TestOutput(outputHelper);
    }

    [Fact]
    public void AreTheyTheSame()
    {
        var peter = new PersonRecord("Peter", "Pan");
        var peter2 = new PersonRecord("Peter", "Pan");

        if (peter == peter2)
        {
            output.WriteLine("The peters are same");
        }

        var tarzan = new PersonRecord("Tarzan", "Porter");
        var jane = tarzan with { FirstName = "Jane" };
        
        if (jane != tarzan)
        {
            output.WriteLine("Peter is married with Jane and they are different.");
        }

        // Defined by constructor
        var personX = new PersonRecord("Dieder", "Timmerman") { WorkYears = 4 };

        // Defined by attributes
        Address adres = new Address { 
            HouseNumber = 36, 
            Street = "LeusderEnd", 
            City="Leusden", 
            Country = "Netherlands", 
            Zipcode = "3832RC" 
        };
        
        personX.Address = adres;

        output.WriteLine($"{personX.LastName} has worked for { personX.WorkYears } in {personX.Address.City}.");
    }
}
