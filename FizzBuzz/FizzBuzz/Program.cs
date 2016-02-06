namespace FizzBuzz
{
	class Program
	{
		static void Main(string[] args)
		{
            FizzBuzz fizzbuzz = new FizzBuzz();
            fizzbuzz.RunFizzBuzz(0);
            fizzbuzz.RunFizzBuzz(1);
            fizzbuzz.RunFizzBuzz(3);
            fizzbuzz.RunFizzBuzz(5);
            fizzbuzz.RunFizzBuzz(15);
            fizzbuzz.RunFizzBuzz(9);
            fizzbuzz.RunFizzBuzz(25);
        }
	}
}
