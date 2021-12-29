namespace WhatsNew.New.Net8_10;

public interface IPersonal
{
    public string FirstName { get; }
    public string LastName { get; }
    public string? MiddleName { get; }

    /// <summary>
    /// Interface can have a implemented getter.
    /// </summary>
    public string FullName => String.Join(" ", FirstName, MiddleName, LastName);

    public int WorkYears { get; }

    /// <summary>
    /// Interface can have an implemented method.
    /// </summary>
    /// <returns></returns>
    public decimal GetDiscount()
    {
        /// Switch with conditions and result
        var discount = WorkYears switch
        {
            <= 2 => 0.01m,
            < 6 or > 10 => 0.2m,
            < 10 => 0.5m,
            _ => 0
        };

        return discount;
    }
}

public class Employee : IPersonal
{
    public string Addressing { get; init; } = "Mr";
    public string FullName => $"{Addressing}{ MiddleName ?? MiddleName : String.Empty} {LastName}"; //override the interface get implemntation FullName
    public int WorkYears { get; set; } = 0;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? MiddleName { get; init; }
    public Address? WorkAddress { get; set; }

    public virtual IPersonal Partner() => new Visitor { FirstName = "Unknown", LastName = "Unknown" };
}


public class Visitor : IPersonal
{
    public int WorkYears { get; private init; } = 0; // The init is set once but not set more then once initializer
    public string FirstName { get; init; } = string.Empty; // Firstname could never be accepted to be null
    public string LastName { get; init; } = string.Empty;
    public string? MiddleName { get; init; } // If not initialized make prop nullable. Its not said middle name may be nullable but can be expected to be nullable
}

public class Applicant : IPersonal
{
    public int WorkYears { get; private init; } = 0;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string? MiddleName { get; init; }
}

public static class Organisation
{
    public static IList<IPersonal> CreateCheckList()
    {

        // Defined by attributes
        Address rubiconAddress = new Address
        {
            HouseNumber = 36,
            Street = "LeusderEnd",
            City = "Leusden",
            Country = "Netherlands",
            Zipcode = "3832RC"
        };

        IList<IPersonal> entranceCheckList = new List<IPersonal> {
            new Employee { Addressing = "Mr", FirstName = "Jacob", LastName = "Parkside", WorkYears = 5 },
            new Employee { Addressing = "Mr", FirstName = "Mac", LastName = "Johnson", WorkYears = 14 },
            new Employee { Addressing = "Mrs.", FirstName = "Jean", MiddleName="the", LastName = "Great", WorkYears =10, WorkAddress = rubiconAddress },
            new Employee { Addressing = "Mrs.", FirstName = "Ellis", MiddleName="", LastName = "Gillmore", WorkYears =10, WorkAddress = rubiconAddress },
            new Applicant { FirstName = "Elya", LastName ="Hanson" },
            new Visitor { FirstName = "Daphne", LastName ="Schippers" }
        };

        return entranceCheckList;

    }
}


