using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineReservationSystem.Domain
{
    [Serializable]
    public sealed class TicketClass
    {
        private TicketClass(string value)
        {
            Value = value;
        }
        public string Value { get; set; }

        public static string Economy { get { return ("Economy"); } }
        public static string EconomyPlus { get { return ("Economy Plus"); } }
        public static string Business { get { return ("Business"); } }
    }
}
