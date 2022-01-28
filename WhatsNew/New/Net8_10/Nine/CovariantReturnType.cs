namespace WhatsNew.New.Net8_10.Nine;

public class Boss : Employee
{

    private Employee? partner;
    public List<Employee> Managing = new(); // target typed constructor

    public void SetPartner(Employee partner)
    {
        this.partner = partner;
    }

    /// <summary>
    /// More specific return type when doing an override
    /// </summary>
    /// <returns></returns>
    public override Employee Partner() => partner ?? new Employee();
}