using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Domain
{
    public static class ValidationHelper
    {
        public static bool UserEnterAlphabetString(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else if (Regex.IsMatch(value, @"^[A-Za-z]+$"))
            {
                return true;
            }
            else return false;
        }

        public static bool UserEnterAlphabetStringWithSpace(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else if (value.Trim().Equals(string.Empty))
            {
                return false;
            }
            else if (Regex.IsMatch(value, @"^[A-Za-z ]+$"))
            {
                return true;
            }
            else return false;
        }

        public static bool UserEnterAlphanumeric(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }
            else if (Regex.IsMatch(value, @"^[a-zA-Z0-9]+$"))
            {
                return true;
            }
            else return false;
        }

        public static bool UserEnterInteger(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }
                else if (Int32.Parse(value) >= 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UserEnterDouble(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }
                else if (double.Parse(value) >= 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }


}
