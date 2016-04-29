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
    public partial class ViewFlightDetailsForm : Form
    {
        private User user;
        private Flight flight;
        private List<Carrier> carrierList;
        private List<Crew> crewList;
        private List<Passenger> passengerList;
        private FlightCrewDAL flightCrewDAL;
        private TicketDAL ticketDAL;
        private PersonDAL personDAL;
        private FlightDAL flightDAL;
        private int state = 0;

        public ViewFlightDetailsForm(Flight flight, List<Carrier> carrierList, User user)
        {
            InitializeComponent();
            this.flight = flight;
            this.user = user;
            this.carrierList = carrierList;
            Init();
        }

        private void Init()
        {
            flightCrewDAL = new FlightCrewDAL();
            ticketDAL = new TicketDAL();
            personDAL = new PersonDAL();
            flightDAL = new FlightDAL();
            LoadComboBoxCarrier();
            for (int i = 0; i < comboBoxCarrier.Items.Count; i++)
            {
                if (flight.FlightCarrier.Name.Equals(comboBoxCarrier.GetItemText(comboBoxCarrier.Items[i])))
                {
                    comboBoxCarrier.SelectedIndex = i;
                }
            }
            textBoxFlightNo.Text = flight.FlightNumber;
            textBoxOrigin.Text = flight.Origin;
            textBoxDestination.Text = flight.Destination;
            textBoxEconomySeat.Text = Convert.ToString(flight.AvailableSeat[TicketClass.Economy]);
            textBoxEconomyPlusSeat.Text = Convert.ToString(flight.AvailableSeat[TicketClass.EconomyPlus]);
            textBoxBusinessSeat.Text = Convert.ToString(flight.AvailableSeat[TicketClass.Business]);
            textBoxEconomyPrice.Text = Convert.ToString(flight.Price[TicketClass.Economy]);
            textBoxEconomyPlusPrice.Text = Convert.ToString(flight.Price[TicketClass.EconomyPlus]);
            textBoxBusinessPrice.Text = Convert.ToString(flight.Price[TicketClass.Business]);
            dateTimePickerDeparture.Value = flight.DepartureTime;
            dateTimePickerArrival.Value = flight.ArrivalTime;
            dateTimePickerDeparture.ShowUpDown = true;
            dateTimePickerDeparture.Format = DateTimePickerFormat.Custom;
            dateTimePickerDeparture.CustomFormat = "ddd dd MMMM yyyy HH:mm";
            dateTimePickerArrival.Format = DateTimePickerFormat.Custom;
            dateTimePickerArrival.ShowUpDown = true;
            dateTimePickerArrival.CustomFormat = "ddd dd MMMM yyyy HH:mm";
            
            LoadDatagridCrew();
            LoadDatagridPassenger();
            AddColumns();
            AdjustColumnOrderCrew();
            //EditPriceAndSeat();
        }

        private void LoadComboBoxCarrier()
        {
            foreach (Carrier c in carrierList)
            {
                comboBoxCarrier.Items.Add(c.Name);
            }
        }

        private void LoadDatagridPassenger()
        {
            passengerList = ticketDAL.GetPassengerFromFlightNumber(flight.FlightNumber);
            var bindingList = new BindingList<Passenger>(passengerList);
            //ticketList = new List<Ticket>();
            //Ticket t = new Ticket(flight, "e", 20, new Passenger("a", "a", "a", "a", DateTime.Now, "a", PersonType.Passenger, "a"));
            //t.TicketId = 333;
            //ticketList.Add(t);
            //var bindingList = new BindingList<Ticket>(ticketList);
            //Console.WriteLine(bindingList.Count());
            //var source = new BindingSource(bindingList, null);
            //if(source==null)
            //{
            //    Console.WriteLine("yes");
            //}
            //Console.WriteLine(source.Count);
            var source = new BindingSource(bindingList, null);
            dataGridViewPassenger.DataSource = null;
            dataGridViewPassenger.DataSource = source;
        }

        private void LoadDatagridCrew()
        {
            crewList = flightCrewDAL.GetAssignedCrewFromFlightNumber(flight.FlightNumber, flight.FlightCarrier);
            var bindingList = new BindingList<Crew>(crewList);
            var source = new BindingSource(bindingList, null);
            dataGridViewCrew.DataSource = null;
            dataGridViewCrew.DataSource = source;
        }

        private void AdjustColumnOrderCrew()
        {
            dataGridViewCrew.Columns["FlightCarrier"].Visible = false;
            dataGridViewCrew.Columns["PersonId"].Visible = false;
            dataGridViewCrew.Columns["DateOfBirth"].Visible = false;
            dataGridViewCrew.Columns["PersonType"].Visible = false;
            dataGridViewCrew.Columns["PassportNo"].DisplayIndex = 1;
            dataGridViewCrew.Columns["PassportNo"].HeaderText = "Passport Number";
            dataGridViewCrew.Columns["FirstName"].HeaderText = "First Name";
            dataGridViewCrew.Columns["LastName"].HeaderText = "Last Name";
        }

        private void AdjustColumnOrderPassenger()
        {
            dataGridViewPassenger.AutoGenerateColumns = false;
            dataGridViewPassenger.Columns["PersonId"].Visible = false;
            dataGridViewPassenger.Columns["PersonType"].Visible = false;
            dataGridViewPassenger.Columns["PassportNo"].DisplayIndex = 0;
            dataGridViewPassenger.Columns["FirstName"].DisplayIndex = 1;
            dataGridViewPassenger.Columns["LastName"].DisplayIndex = 2;
            dataGridViewPassenger.Columns["DateOfBirth"].DisplayIndex = 3;
            dataGridViewPassenger.Columns["Gender"].DisplayIndex = 4;
            dataGridViewPassenger.Columns["Nationality"].DisplayIndex = 5;
            dataGridViewPassenger.Columns["FrequentFlyer"].DisplayIndex = 6;
            dataGridViewPassenger.Columns["SeatClass"].DisplayIndex = 7;
            dataGridViewPassenger.Columns["Price"].DisplayIndex = 8;
            dataGridViewPassenger.Columns["DateOfBirth"].HeaderText = "Date of Birth";
            dataGridViewPassenger.Columns["FrequentFlyer"].HeaderText = "Frequent Flyer";
            dataGridViewPassenger.Columns["PassportNo"].HeaderText = "Passport Number";
            dataGridViewPassenger.Columns["FirstName"].HeaderText = "First Name";
            dataGridViewPassenger.Columns["LastName"].HeaderText = "Last Name";
            dataGridViewPassenger.Columns["DateOfBirth"].DefaultCellStyle = new DataGridViewCellStyle
            { Format = "MM'/'dd'/'yyyy" };
        }

        private void AddColumns()
        {
            dataGridViewPassenger.Columns.Add("SeatClass", "Seat Class");
            dataGridViewPassenger.Columns.Add("Price", "Price");
        }

        private void EditPriceAndSeat()
        {
            dataGridViewPassenger.Columns["SeatClass"].ValueType = typeof(string);
            dataGridViewPassenger.Columns["Price"].ValueType = typeof(double);
            foreach (DataGridViewRow row in dataGridViewPassenger.Rows)
            {
                var pass = (Passenger)row.DataBoundItem;
                Ticket t = ticketDAL.SearchTicketByPassenger(pass);
                row.Cells["SeatClass"].Value = t.SeatClass;
                row.Cells["Price"].Value = t.Price;
            }
        }

        private void buttonBookTicket_Click(object sender, EventArgs e)
        {
            this.Close();
            BookTicketForm bookTicketForm = new BookTicketForm(flight, user);
            bookTicketForm.ShowDialog();
        }

        private void buttonGoToUnbookTicket_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabPagePassenger;
        }

        private void buttonConfirmUnbook_Click(object sender, EventArgs e)
        {
            if (dataGridViewPassenger.RowCount > 0)
            {
                Passenger passenger = (Passenger)dataGridViewPassenger.CurrentRow.DataBoundItem;
                DialogResult dr = MessageBox.Show("Are you sure you want to unbook this ticket?",
                "Airline Reservation System Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        Ticket ticket = ticketDAL.SearchTicketByPassenger(passenger);
                        if (ticket.SeatClass.Equals(TicketClass.Business))
                        {
                            flight.AvailableSeat[TicketClass.Business] = flight.AvailableSeat[TicketClass.Business] + 1;
                        }
                        else if (ticket.SeatClass.Equals(TicketClass.Economy))
                        {
                            flight.AvailableSeat[TicketClass.Economy] = flight.AvailableSeat[TicketClass.Economy] + 1;
                        }
                        else
                        {
                            flight.AvailableSeat[TicketClass.EconomyPlus] = flight.AvailableSeat[TicketClass.EconomyPlus] + 1;
                        }
                        ticketDAL.DeleteTicket(ticket);
                        personDAL.DeletePerson(passenger);

                        flightDAL.UpdateAvailableSeat(flight);
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
                        LoadDatagridPassenger();
                        AdjustColumnOrderPassenger();
                        EditPriceAndSeat();
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
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to unbook", "Airline Reservation System Warning");
            }
        }
        
        private void dataGridViewVisibleChanged(object sender, EventArgs e)
        {
            if(state==0)
            {
                AdjustColumnOrderPassenger();
                EditPriceAndSeat();
                state++;
            }
            
        }
    }
}
