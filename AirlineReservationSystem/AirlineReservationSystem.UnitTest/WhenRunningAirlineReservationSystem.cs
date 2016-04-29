using System;
using NUnit.Framework;
using AirlineReservationSystem.Domain;

namespace AirlineReservationSystem.UnitTest
{
    [TestFixture]
    public class WhenRunningAirlineReservationSystem
    {
        #region UserEnterAlphabetString Tests
        [Test]
        public void When_UserEnterAlphabetString_ValidStringEntered_ResultShouldBeTrue()
        {
            var expected = true;
            var actual = ValidationHelper.UserEnterAlphabetString("David");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphabetString_NullEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphabetString(null);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphabetString_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphabetString("  ");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphabetString_EmptyStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphabetString(string.Empty);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphabetString_InValidStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphabetString("Doctor. James 34");
            Assert.That(expected, Is.EqualTo(actual));
        }
        #endregion

        #region UserEnterAlphabetStringWithSpace Tests
        [Test]
        public void When_UserEnterAlphabetStringWithSpace_ValidStringEntered_ResultShouldBeTrue()
        {
            var expected = true;
            var actual = ValidationHelper.UserEnterAlphabetStringWithSpace("David Hilton");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphabetStringWithSpace_NullEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphabetStringWithSpace(null);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphabetStringWithSpace_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphabetStringWithSpace("  ");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphabetStringWithSpace_EmptyStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphabetStringWithSpace(string.Empty);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphabetStringWithSpace_InValidStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphabetStringWithSpace("Doctor. James 34");
            Assert.That(expected, Is.EqualTo(actual));
        }
        #endregion

        #region UserEnterAlphanumeric Tests
        [Test]
        public void When_UserEnterAlphanumeric_ValidStringEntered_ResultShouldBeTrue()
        {
            var expected = true;
            var actual = ValidationHelper.UserEnterAlphanumeric("AA00032");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphanumeric_NullEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphanumeric(null);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphanumeric_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphanumeric("  ");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphanumeric_EmptyStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphanumeric(string.Empty);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterAlphanumeric_InValidStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterAlphanumeric("RR#$@#");
            Assert.That(expected, Is.EqualTo(actual));
        }
        
        #endregion

        #region UserEnterInteger Tests
        [Test]
        public void When_UserEnterInteger_ValidStringEntered_ResultShouldBeTrue()
        {
            var expected = true;
            var actual = ValidationHelper.UserEnterInteger("32");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterInteger_NullEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterInteger(null);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterInteger_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterInteger("  ");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterInteger_EmptyStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterInteger(string.Empty);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterInteger_InValidStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterInteger("RR#$@#");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterInteger_NegativeNumberEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterInteger("-3");
            Assert.That(expected, Is.EqualTo(actual));
        }
        #endregion

        #region UserEnterDouble Tests
        [Test]
        public void When_UserEnterDouble_ValidStringEntered_ResultShouldBeTrue()
        {
            var expected = true;
            var actual = ValidationHelper.UserEnterDouble("32.99");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterDouble_NullEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterDouble(null);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterDouble_WhiteSpaceEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterDouble("  ");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterDouble_EmptyStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterDouble(string.Empty);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterDouble_InValidStringEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterDouble("RR#$@#");
            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void When_UserEnterDouble_NegativeNumberEntered_ResultShouldBeFalse()
        {
            var expected = false;
            var actual = ValidationHelper.UserEnterDouble("-3.33");
            Assert.That(expected, Is.EqualTo(actual));
        }
        #endregion
    }
}
