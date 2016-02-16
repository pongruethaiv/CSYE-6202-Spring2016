using System;

namespace GasPump
{
	public class Program
	{
		public enum GasType
		{
			None,
			RegularGas,
			MidgradeGas,
			PremiumGas,
			DieselFuel				
		}

		static void Main(string[] args)
		{
			// your implementation here
		}

		// use this method to check and see if sentinel value is entered
		public static bool UserEnteredSentinelValue(string userInput)
		{
			var result = false;

			// your implementation here

			return result;
		}

		// use this method to parse and check the characters entered
		// this does not conform 
		public static bool UserEnteredValidGasType(string userInput)
		{
			var result = false;

			// your implementation here
			
			return result;
		}

		// use this method to parse and check the double type entered
		// please use Double.TryParse() method 
		public static bool UserEnteredValidAmount(string userInput)
		{
			var result = false;

			// your implementation here

			return result;
		}

		// use this method to map a valid char entry to its enum representation
		// e.g. User enters 'R' or 'r' --> this should be mapped to GasType.RegularGas
		// this mapping "must" be used within CalculateTotalCost() method later on
		public static GasType GasTypeMapper(char c)
		{
			GasType gasType = GasType.None;

			// your implementation here

			return gasType;
		}

		public static double GasPriceMapper(GasType gasType)
		{
			var result = 0.0;

			// your implementation here

			return result;
	}

		public static void CalculateTotalCost(GasType gasType, int gasAmount, ref double totalCost)
		{
			// your implementation here
		}
	}
}
