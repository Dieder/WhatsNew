namespace WhatsNew.New.Net8_10;

public class PatternMatchingType
{
    private readonly IOutput output;
    public PatternMatchingType(IOutput output)
    {
        this.output= output;
    }

    public void GetVistorType(IPersonal personal)
    {
        if (personal is Employee or Applicant)
        {
            output.WriteLine(personal.FullName + " is employee or applicant.");
        }
        else
        {
            output.WriteLine(personal.FullName + " is other");
        }

        if (personal is not Employee)
        {
            output.WriteLine(personal.FullName + " is not an employee.");
        }
    }

   

}

