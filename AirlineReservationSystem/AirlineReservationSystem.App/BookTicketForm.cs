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
    public partial class BookTicketForm : Form
    {
        private User user;
        private Flight flight;
        private TicketDAL ticketDAL;
        private PassengerDAL passengerDAL;
        private PersonDAL personDAL;
        private FlightDAL flightDAL;

        public BookTicketForm(Flight flight, User user)
        {
            InitializeComponent();
            this.user = user;
            this.flight = flight;
            Init();
        }

        private void Init()
        {
            ticketDAL = new TicketDAL();
            flightDAL = new FlightDAL();
            personDAL = new PersonDAL();
            passengerDAL = new PassengerDAL();

            textBoxEconomySeat.Text = Convert.ToString(flight.AvailableSeat[TicketClass.Economy]);
            textBoxEconomyPlusSeat.Text = Convert.ToString(flight.AvailableSeat[TicketClass.EconomyPlus]);
            textBoxBusinessSeat.Text = Convert.ToString(flight.AvailableSeat[TicketClass.Business]);
            textBoxEconomyPrice.Text = Convert.ToString(flight.Price[TicketClass.Economy]);
            textBoxEconomyPlusPrice.Text = Convert.ToString(flight.Price[TicketClass.EconomyPlus]);
            textBoxBusinessPrice.Text = Convert.ToString(flight.Price[TicketClass.Business]);

            dateTimePickerDob.Value = DateTime.Now;
            dateTimePickerDob.MaxDate = DateTime.Now;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            string first = textBoxFirst.Text;
            string last = textBoxLast.Text;
            string passport = textBoxPassport.Text;
            string nation = textBoxNationality.Text;
            string frequentFly = textBoxFrequentFlyer.Text;

            if (string.IsNullOrEmpty(first) || first.Trim().Equals("") ||
                string.IsNullOrEmpty(last) || last.Trim().Equals("") ||
                string.IsNullOrEmpty(passport) || passport.Trim().Equals("") ||
                string.IsNullOrEmpty(nation) || nation.Trim().Equals("") ||
                string.IsNullOrEmpty(frequentFly) || frequentFly.Trim().Equals("") ||
                (!radioButtonMale.Checked && !radioButtonFemale.Checked) || 
                (!radioButtonBusiness.Checked && !radioButtonEconomy.Checked && !radioButtonEconomyPlus.Checked))
            {
                MessageBox.Show("Please fill in all the fields", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ValidationHelper.UserEnterAlphabetString(first) && ValidationHelper.UserEnterAlphabetString(last)
                    && ValidationHelper.UserEnterAlphanumeric(passport) && ValidationHelper.UserEnterAlphabetString(nation)
                    && ValidationHelper.UserEnterAlphanumeric(frequentFly))
                {
                    var ticketList = ticketDAL.GetTicketFromFlightNumber(flight.FlightNumber);
                    foreach (Ticket t in ticketList)
                    {
                        if (t.Passenger.PassportNo.ToLower().Equals(passport.ToLower()))
                        {
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                LogAppend.Log("(" + user.Role + ": " + user.Username + ") attemped to book ticket with duplicate passport no. in one flight", w);
                            }

                            using (StreamReader r = File.OpenText("log.txt"))
                            {
                                LogAppend.DumpLog(r);
                            }
                            MessageBox.Show("Duplicate passport no. for this flight", "Airline Reservation System Warning");
                            goto exitLoop;
                        }
                    }
                    string gender;
                    string ticketClass;
                    double price;

                    DateTime dob = dateTimePickerDob.Value;
                    if (radioButtonFemale.Checked)
                    {
                        gender = "Female";
                    }
                    else gender = "Male";
                    if (radioButtonBusiness.Checked)
                    {
                        ticketClass = TicketClass.Business;
                        int availSeat = flight.AvailableSeat[TicketClass.Business];
                        if (availSeat >= 1)
                        {
                            price = flight.Price[TicketClass.Business];
                            flight.AvailableSeat[TicketClass.Business] = flight.AvailableSeat[TicketClass.Business] - 1;
                        }
                        else goto endOfLoop;
                    }
                    else if (radioButtonEconomy.Checked)
                    {
                        ticketClass = TicketClass.Economy;
                        int availSeat = flight.AvailableSeat[TicketClass.Economy];
                        if (availSeat >= 1)
                        {
                            price = flight.Price[TicketClass.Economy];
                            flight.AvailableSeat[TicketClass.Economy] = flight.AvailableSeat[TicketClass.Economy] - 1;
                        }
                        else goto endOfLoop;
                    }
                    else {
                        ticketClass = TicketClass.EconomyPlus;
                        int availSeat = flight.AvailableSeat[TicketClass.EconomyPlus];
                        if (availSeat >= 1)
                        {
                            price = flight.Price[TicketClass.EconomyPlus];
                            flight.AvailableSeat[TicketClass.EconomyPlus] = flight.AvailableSeat[TicketClass.EconomyPlus] - 1;
                        }
                        else goto endOfLoop;
                    }
                    try
                    {
                        flightDAL.UpdateAvailableSeat(flight);
                        Person p = new Passenger(first, last, passport, gender, dob, nation, PersonType.Passenger, frequentFly);
                        Ticket ticket = new Ticket(flight, ticketClass, price, (Passenger)p);
                        int id = personDAL.InsertPerson(p);
                        p.PersonId = id;
                        passengerDAL.InsertPassenger((Passenger)p);
                        int ticketId = ticketDAL.InsertTicket(ticket);
                        ticket.TicketId = ticketId;
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") created new passenger: " + p.PassportNo+" to flight: "+ticket.Flight.FlightNumber, w);
                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") booked new ticket: " + ticket.TicketId, w);
                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated available seat for flight: " + ticket.Flight.FlightNumber, w);
                        }

                        using (StreamReader r = File.OpenText("log.txt"))
                        {
                            LogAppend.DumpLog(r);
                        }
                        this.Close();
                        BookTicketConfirmationForm ticketConfirmForm = new BookTicketConfirmationForm(ticket, user);
                        ticketConfirmForm.ShowDialog();
                        goto exitLoop;
                    }
                    catch (SqlException ex)
                    {
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            if (ex.Number == 2627)
                            {
                                LogAppend.Log("(" + user.Role + ": " + user.Username + ") attemped to book ticket with duplicate data", w);
                                MessageBox.Show("Duplicate data", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                LogAppend.Log("(" + user.Role + ": " + user.Username + ") exception occured: "+ex.Message, w);
                                MessageBox.Show("Execute exception issue: " + ex.Message);
                            }
                        }
                        using (StreamReader r = File.OpenText("log.txt"))
                        {
                            LogAppend.DumpLog(r);
                        }
                        goto exitLoop;
                    }
                    endOfLoop: MessageBox.Show("No seat available", "Airline Reservation System Warning");
                    
                }
                else
                {
                    MessageBox.Show("Invalid inputs", "Airline Reservation System Warning");
                }
                
                exitLoop:;
            }
                
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFrequentFlyer.Text = "";
            textBoxFirst.Text = "";
            textBoxLast.Text = "";
            textBoxNationality.Text = "";
            textBoxPassport.Text = "";
            dateTimePickerDob.MaxDate = DateTime.Now;
            dateTimePickerDob.Value = DateTime.Now;
            radioButtonBusiness.Checked = false;
            radioButtonEconomy.Checked = false;
            radioButtonEconomyPlus.Checked = false;
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
        }
    }
}
