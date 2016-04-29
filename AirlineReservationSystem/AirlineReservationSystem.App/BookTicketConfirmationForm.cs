using AirlineReservationSystem.DAL;
using AirlineReservationSystem.Domain;
using AirlineReservationSystem.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservationSystem.App
{
    public partial class BookTicketConfirmationForm : Form
    {
        private User user;
        private Ticket ticket;
        private TicketDAL ticketDAL;
        private PersonDAL personDAL;
        private FlightDAL flightDAL;

        public BookTicketConfirmationForm(Ticket ticket, User user)
        {
            InitializeComponent();
            this.user = user;
            this.ticket = ticket;
            Init();
        }

        private void Init()
        {
            ticketDAL = new TicketDAL();
            personDAL = new PersonDAL();
            flightDAL = new FlightDAL();
            LoadTicketDetails();
        }
        private void LoadTicketDetails()
        {
            textBoxBookingNo.Text = Convert.ToString(ticket.TicketId);
            textBoxCarrier.Text = ticket.Flight.FlightCarrier.Name;
            textBoxFirst.Text = ticket.Passenger.FirstName;
            textBoxLast.Text = ticket.Passenger.LastName;
            textBoxPassport.Text = ticket.Passenger.PassportNo;
            textBoxFlightNo.Text = ticket.Flight.FlightNumber;
            textBoxOrigin.Text = ticket.Flight.Origin;
            textBoxDepartTime.Text = ticket.Flight.DepartureTime.ToString("ddd dd MMMM yyyy hh:mm tt");
            textBoxDestination.Text = ticket.Flight.Destination;
            textBoxArriveTime.Text = ticket.Flight.ArrivalTime.ToString("ddd dd MMMM yyyy hh:mm tt");
            textBoxPrice.Text = Convert.ToString(ticket.Price);
            textBoxSeatClass.Text = ticket.SeatClass;
            textBoxFrequentFlyer.Text = ticket.Passenger.FrequentFlyer;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUnbook_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to unbook this ticket?",
                "Airline Reservation System Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                if (ticket.SeatClass.Equals(TicketClass.Business))
                {
                    ticket.Flight.AvailableSeat[TicketClass.Business] = ticket.Flight.AvailableSeat[TicketClass.Business] + 1;
                }
                else if (ticket.SeatClass.Equals(TicketClass.Economy))
                {
                    ticket.Flight.AvailableSeat[TicketClass.Economy] = ticket.Flight.AvailableSeat[TicketClass.Economy] + 1;
                }
                else
                {
                    ticket.Flight.AvailableSeat[TicketClass.EconomyPlus] = ticket.Flight.AvailableSeat[TicketClass.EconomyPlus] + 1;
                }
                try
                {
                    personDAL.DeletePerson(ticket.Passenger);
                    ticketDAL.DeleteTicket(ticket);
                    flightDAL.UpdateAvailableSeat(ticket.Flight);
                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") deleted passenger: " + ticket.Passenger.PassportNo + " from flight: " + ticket.Flight.FlightNumber, w);
                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") unbooked ticket: " + ticket.TicketId, w);
                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated available seat for flight: " + ticket.Flight.FlightNumber, w);
                    }

                    using (StreamReader r = File.OpenText("log.txt"))
                    {
                        LogAppend.DumpLog(r);
                    }
                }
                catch (SqlException ex)
                {
                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") exception occured: " + ex.Message, w);
                        MessageBox.Show("Execute exception issue: " + ex.Message);
                    }
                    using (StreamReader r = File.OpenText("log.txt"))
                    {
                        LogAppend.DumpLog(r);
                    }
                }
                
                this.Close();
            }
        }
    }
}
