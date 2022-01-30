using WhatsNew.New.Net8_10.Nine;

namespace TestProject1.Nine;

public class CovariantReturnTypeTests
{
    [Fact]
    public void GetEmployees()
    {
        var entranceCheckList = Organisation.CreateCheckList();

        foreach (var todaysVisitor in entranceCheckList)
        {

            if (todaysVisitor is Employee employee)
            {
                var visitorPartner = employee.Partner();
                Assert.IsAssignableFrom<IPersonal>(visitorPartner);
            }

            if (todaysVisitor is Boss boss) // class boss is derived from employee!
            {
                var employeePartner = boss.Partner(); //boss has a different return type however
                Assert.IsAssignableFrom<Employee>(employeePartner);
            }
        }
    }

}
