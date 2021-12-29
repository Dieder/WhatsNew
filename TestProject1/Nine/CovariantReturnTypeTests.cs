using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsNew.New.Net8_10.Nine;

namespace TestProject1.Nine;

public class CovariantReturnTypeTests
{
    [Fact]
    public void GetEmployees()
    {
        var entranceCheckList = Organisation.CreateCheckList();

        foreach(var visitor in entranceCheckList)
        {
            
            if (visitor is Employee employee)
            {
                var visitorPartner = employee.Partner();
                Assert.IsAssignableFrom<IPersonal>(visitorPartner);
            }

            if (visitor is Boss boss) // class boss is derived from employee!
            {
                var employeePartner = boss.Partner(); //boss has a different return type however
                Assert.IsAssignableFrom<Employee>(employeePartner); 
            }
        }
    }

}
