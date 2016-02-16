using NUnit.Framework;

namespace GasPump.Tests
{
	[TestFixture]
	public class WhenRunningGasPump
	{
		#region UserEnteredSentinelValue Tests

		[Test]
		public void When_UserEnteredSentinelValue_LowerCaseSentinelValueEntered_ResultShouldBeTrue()
		{
			// prepare
			var expected = true;

			// action
			var actual = Program.UserEnteredSentinelValue("q");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredSentinelValue_UpperCaseSentinelValueEntered_ResultShouldBeTrue()
		{
			// prepare
			var expected = true;

			// action
			var actual = Program.UserEnteredSentinelValue("Q");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredSentinelValue_NullValueEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredSentinelValue(null);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredSentinelValue_WhiteSpaceEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredSentinelValue(" ");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredSentinelValue_MoreThanOneCharacterEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredSentinelValue("re");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredSentinelValue_NonSentinelValueEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredSentinelValue("z");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		#endregion

		#region UserEnteredValidGasType Tests

		[Test]
		public void When_UserEnteredValidGasType_UpperCaseValidGasTypeEntered_ResultShouldBeTrue()
		{
			// prepare
			var expected = true;

			// action
			var actual = Program.UserEnteredValidGasType("R");

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.UserEnteredValidGasType("M");

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.UserEnteredValidGasType("P");

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.UserEnteredValidGasType("D");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredValidGasType_LowerCaseValidGasTypeEntered_ResultShouldBeTrue()
		{
			// prepare
			var expected = true;

			// action
			var actual = Program.UserEnteredValidGasType("r");

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.UserEnteredValidGasType("m");

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.UserEnteredValidGasType("p");

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.UserEnteredValidGasType("d");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredValidGasType_NullValueEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredValidGasType(null);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredValidGasType_WhiteSpaceEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredValidGasType(" ");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredValidGasType_MoreThanOneCharacterEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredValidGasType("re");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredValidGasType_InvalidGasTypeEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredValidGasType("T");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		#endregion

		#region UserEnteredValidAmount Tests

		[Test]
		public void When_UserEnteredValidAmount_ValidAmountEntered_ResultShouldBeTrue()
		{
			// prepare
			var expected = true;

			// action
			var actual = Program.UserEnteredValidAmount("10.00");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredValidAmount_NullValueEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredValidAmount(null);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredValidAmount_WhiteSpaceEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredValidAmount(" ");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_UserEnteredValidAmount_InvalidAmountEntered_ResultShouldBeFalse()
		{
			// prepare
			var expected = false;

			// action
			var actual = Program.UserEnteredValidAmount("gibberish amount");

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		#endregion

		#region GasTypeMapper Tests

		[Test]
		public void When_GasTypeMapper_rOrRIsEntered_ResultShouldBeRegularGas()
		{
			// prepare
			var expected = Program.GasType.RegularGas;

			// action
			var actual = Program.GasTypeMapper('r');

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.GasTypeMapper('R');

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_GasTypeMapper_mOrMIsEntered_ResultShouldBeMidgradeGas()
		{
			// prepare
			var expected = Program.GasType.MidgradeGas;

			// action
			var actual = Program.GasTypeMapper('m');

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.GasTypeMapper('M');

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_GasTypeMapper_pOrPIsEntered_ResultShouldBePremiumGas()
		{
			// prepare
			var expected = Program.GasType.PremiumGas;

			// action
			var actual = Program.GasTypeMapper('p');

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.GasTypeMapper('P');

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_GasTypeMapper_dOrDIsEntered_ResultShouldBeDieselFuel()
		{
			// prepare
			var expected = Program.GasType.DieselFuel;

			// action
			var actual = Program.GasTypeMapper('d');

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.GasTypeMapper('D');

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_GasTypeMapper_InvalidCharacterIsEntered_ResultShouldBeNone()
		{
			// prepare
			var expected = Program.GasType.None;

			// action
			var actual = Program.GasTypeMapper('a');

			// assert
			Assert.That(expected, Is.EqualTo(actual));

			// action
			actual = Program.GasTypeMapper('A');

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		#endregion

		#region GasPriceMapper Tests

		[Test]
		public void When_GasPriceMapper_RegularGasIsEntered_ResultShouldBeRegularGasPrice()
		{
			// prepare
			var expected = 1.94;

			// action
			var actual = Program.GasPriceMapper(Program.GasType.RegularGas);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_GasPriceMapper_MidgradeGasIsEntered_ResultShouldBeMidgradeGasPrice()
		{
			// prepare
			var expected = 2.00;

			// action
			var actual = Program.GasPriceMapper(Program.GasType.MidgradeGas);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_GasPriceMapper_PremiumGasIsEntered_ResultShouldBePremiumGasPrice()
		{
			// prepare
			var expected = 2.24;

			// action
			var actual = Program.GasPriceMapper(Program.GasType.PremiumGas);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_GasPriceMapper_DieselFuelIsEntered_ResultShouldBeDieselFuel()
		{
			// prepare
			var expected = 2.17;

			// action
			var actual = Program.GasPriceMapper(Program.GasType.DieselFuel);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		[Test]
		public void When_GasPriceMapper_InvalidGasTypeIsEntered_ResultShouldBeZero()
		{
			// prepare
			var expected = 0.0;

			// action
			var actual = Program.GasPriceMapper(Program.GasType.None);

			// assert
			Assert.That(expected, Is.EqualTo(actual));
		}

		#endregion

		#region CalculateTotalCost Tests

		[Test]
		public void When_CalculateTotalCost_RegularGasIsEntered_ResultShouldBeRegularGasPriceTimesAmount()
		{
			// prepare
			double expected = 194;
			var amount = 100;
			var totalCost = 0.0;

			// action
			Program.CalculateTotalCost(Program.GasType.RegularGas, amount, ref totalCost);

			// assert
			Assert.That(expected, Is.EqualTo((int)totalCost));
		}

		[Test]
		public void When_CalculateTotalCost_MidgradeGasIsEntered_ResultShouldBeMidgradeGasPriceTimesAmount()
		{
			// prepare
			double expected = 200;
			var amount = 100;
			var totalCost = 0.0;

			// action
			Program.CalculateTotalCost(Program.GasType.MidgradeGas, amount, ref totalCost);

			// assert
			Assert.That(expected, Is.EqualTo((int)totalCost));
		}

		[Test]
		public void When_CalculateTotalCost_PremiumGasIsEntered_ResultShouldBePremiumGasPriceTimesAmount()
		{
			// prepare
			var expected = 224;
			var amount = 100;
			var totalCost = 0.0;

			// action
			Program.CalculateTotalCost(Program.GasType.PremiumGas, amount, ref totalCost);

			// assert
			Assert.That(expected, Is.EqualTo((int)totalCost));
		}

		[Test]
		public void When_CalculateTotalCost_DieselFuelIsEntered_ResultShouldBeDieselFuelTimesAmount()
		{
			// prepare
			double expected = 217;
			var amount = 100;
			var totalCost = 0.0;

			// action
			Program.CalculateTotalCost(Program.GasType.DieselFuel, amount, ref totalCost);

			// assert
			Assert.That(expected, Is.EqualTo((int)totalCost));
		}

		[Test]
		public void When_CalculateTotalCost_InvalidGasTypeIsEntered_ResultShouldBeZero()
		{
			// prepare
			double expected = 0;
			var amount = 100;
			var totalCost = 0.0;

			// action
			Program.CalculateTotalCost(Program.GasType.None, amount, ref totalCost);

			// assert
			Assert.That(expected, Is.EqualTo((int)totalCost));
		}

		#endregion
	}
}
