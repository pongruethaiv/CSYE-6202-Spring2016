using System;

namespace TrianglePatterns
{
	class Program
	{
		static void Main(string[] args)
		{
			DisplayPatternA();
			DisplayPatternB();
			DisplayPatternC();
			DisplayPatternD();

			Console.ReadLine();
		}

		static void DisplayPatternA()
		{
            Console.WriteLine("Pattern A");
            for (int i=1; i<=10; i++) //line number
            {
                for (int j=1; j<=i; j++) //number of stars
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }

		static void DisplayPatternB()
		{
            Console.WriteLine("Pattern B");
            for (int i=1; i<=10; i++)
            {
                for (int j=10; j>=i; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }

		static void DisplayPatternC()
		{
            Console.WriteLine("Pattern C");
            for (int i=1; i<=10; i++)
            {
                for (int s=1; s<i; s++) //number of spaces
                {
                    Console.Write(" ");
                }
                for (int j=10; j>=i; j--)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }

		static void DisplayPatternD()
		{
            Console.WriteLine("Pattern D");
            for (int i=1; i<=10; i++)
            {
                for (int s=10; s>=i; s--)
                {
                    Console.Write(" ");
                }
                for (int j=1; j<=i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }
	}
}
