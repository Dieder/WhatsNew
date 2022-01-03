namespace WhatsNew.New.Net8_10;

public record PersonRecord(string FirstName, string LastName, string? MiddleName = null) : IPersonal
{
    public Address? Address { get; set; }
    public int WorkYears { get; set; }
}

public record Address
{
    public string? Street { get; init; }
    public string? City { get; init; }
    public string? Zipcode { get; init; }
    public string? Country { get; init; }
    public int? HouseNumber { get; init; }
}