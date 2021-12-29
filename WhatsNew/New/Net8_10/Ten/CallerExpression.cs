using System.Runtime.CompilerServices;

namespace WhatsNew.New.Net8_10
{
    public class CallerExpression
    {
        public static T EnsureArgumentIsNotNull<T>(T value, [CallerArgumentExpression("value")] string? expression = null)
        {
            if (value is null)
                throw new ArgumentNullException(expression);
            return value;
        }
        
    }
}
