namespace WhatsNew.New.Net8_10;

public class Lambdas
    {

        private static Func<int,int,int> mymethod => (int a, int b) => a + b;

        public void methods() {            
            Console.WriteLine(mymethod(12, 3));
        }
    }

