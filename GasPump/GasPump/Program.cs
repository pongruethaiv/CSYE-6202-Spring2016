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
            String input = "";
            while (!UserEnteredSentinelValue(input))
            {
                while (!UserEnteredValidGasType(input))
                {
                    Console.Write("Please enter purchased gas type, Q/q to quit: ");
                    input = Console.ReadLine();
                    if (UserEnteredSentinelValue(input))
                    {
                        goto endOfLoop;
                    }
                }
                String gasTypeString = input;

                input = "";
                while (!UserEnteredValidAmount(input))
                {
                    Console.Write("Please enter purchased gas amount, Q/q to quit: ");
                    input = Console.ReadLine();
                    if (UserEnteredSentinelValue(input))
                    {
                        goto endOfLoop;
                    }
                }

                GasType gasType = GasTypeMapper(Convert.ToChar(gasTypeString));
                double totalCost = 0;
                CalculateTotalCost(gasType, Convert.ToInt32(Convert.ToDouble(input)), ref totalCost);
            }

            endOfLoop: Console.WriteLine("Application terminated");
        }

		// use this method to check and see if sentinel value is entered
		public static bool UserEnteredSentinelValue(string userInput)
		{
			var result = false;

            if (object.ReferenceEquals(null, userInput))
            {
                result = false;
            }
            else if (userInput.ToLower().Equals("q"))
            {
                result = true;
            }
			return result;
		}

        // use this method to parse and check the characters entered
        // this does not conform 
        public static bool UserEnteredValidGasType(string userInput)
        {
            var result = false;

            if (object.ReferenceEquals(null, userInput))
            {
                result = false;
            }
            else if (userInput.ToLower().Equals("r") || userInput.ToLower().Equals("m") || 
                userInput.ToLower().Equals("p")|| userInput.ToLower().Equals("d"))
            {
                result = true;
            }
			
			return result;
		}

		// use this method to parse and check the double type entered
		// please use Double.TryParse() method 
		public static bool UserEnteredValidAmount(string userInput)
		{
			var result = false;

            Double value;
            if (Double.TryParse(userInput, out value)) {
                result = true;
            }

            return result;
		}

		// use this method to map a valid char entry to its enum representation
		// e.g. User enters 'R' or 'r' --> this should be mapped to GasType.RegularGas
		// this mapping "must" be used within CalculateTotalCost() method later on
		public static GasType GasTypeMapper(char c)
		{
			GasType gasType = GasType.None;

            if (c.Equals('r') || c.Equals('R')) gasType = GasType.RegularGas;
            else if (c.Equals('m') || c.Equals('M')) gasType = GasType.MidgradeGas;
            else if (c.Equals('p') || c.Equals('P')) gasType = GasType.PremiumGas;
            else if (c.Equals('d') || c.Equals('D')) gasType = GasType.DieselFuel;

			return gasType;
		}

		public static double GasPriceMapper(GasType gasType)
		{
			var result = 0.0;

            if (gasType.Equals(GasType.RegularGas)) result = 1.94;
            else if (gasType.Equals(GasType.MidgradeGas)) result = 2;
            else if (gasType.Equals(GasType.PremiumGas)) result = 2.24;
            else if (gasType.Equals(GasType.DieselFuel)) result = 2.17;

            return result;
	}
    
		public static void CalculateTotalCost(GasType gasType, int gasAmount, ref double totalCost)
		{
            double price = GasPriceMapper(gasType);
            totalCost = gasAmount * price;
            Console.WriteLine("You bought {0} gallons of {1} at ${2}", gasAmount, gasType, price);
            Console.WriteLine("Your total cost for this purchase is: ${0}", totalCost);
        }
	}
}
