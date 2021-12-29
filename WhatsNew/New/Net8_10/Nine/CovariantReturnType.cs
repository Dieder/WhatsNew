namespace WhatsNew.New.Net8_10.Nine;

public class Boss : Employee
{

    public List<Employee> Managing = new(); // target typed constructor

    /// <summary>
    /// More specific return type when doing an override
    /// </summary>
    /// <returns></returns>
    public override Employee Partner() => new Employee { FirstName = "Unknown", LastName = "Unknown" };
}