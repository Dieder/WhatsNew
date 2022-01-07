namespace TestProject1
{
    public class TestLambdas
    {
        [Fact]
        public void Test()
        {
            var isEven = (int n) => n % 2 == 0;
            var isEvenString = string (int n) => (n % 2 == 0).ToString();

            var AddOne = (ref int n) => n++;

            Assert.False(isEven(3));
            Assert.True(isEven(4));
            int number = 4;
            AddOne(ref number);
            Assert.Equal(5, number);
        }
    }
}