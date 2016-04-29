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
    public partial class ViewUpdateFlightDetailsForm : Form
    {
        private User user;
        private Flight flight;
        private string oldFlightNo;
        private CarrierDAL carrierDAL;
        private CrewDAL crewDAL;
        private FlightDAL flightDAL;
        private FlightCrewDAL flightCrewDAL;
        private TicketDAL ticketDAL;
        private List<Crew> crewList;
        private List<Passenger> passengerList;
        public List<Crew> CrewListUpdate { get; set; }
        private Carrier oldCarrier;
        private int state = 0;

        public ViewUpdateFlightDetailsForm(Flight flight, User user)
        {
            this.user = user;
            InitializeComponent();
            this.flight = flight;
            oldFlightNo = flight.FlightNumber;
            Init();
        }

        private void Init()
        {
            carrierDAL = new CarrierDAL();
            flightDAL = new FlightDAL();
            flightCrewDAL = new FlightCrewDAL();
            ticketDAL = new TicketDAL();
            crewDAL = new CrewDAL();
            oldCarrier = flight.FlightCarrier;
            LoadDatagridCrew();
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
            
            //AddCheckBoxColumnToDataGrid();
            LoadDatagridPassenger();
            AddColumns();
            AdjustColumnOrderCrew();
        }

        private void LoadComboBoxCarrier()
        {
            foreach (Carrier c in carrierDAL.GetCarrierList())
            {
                comboBoxCarrier.Items.Add(c.Name);
            }
        }

        private void LoadDatagridCrew()
        {
            crewList = flightCrewDAL.GetAssignedCrewFromFlightNumber(flight.FlightNumber, flight.FlightCarrier);
            var bindingList = new BindingList<Crew>(crewList);
            var source = new BindingSource(bindingList, null);
            dataGridViewCrews.DataSource = null;
            dataGridViewCrews.DataSource = source;
            //AdjustColumnOrder();
        }

        private void LoadDatagridPassenger()
        {
            passengerList = ticketDAL.GetPassengerFromFlightNumber(flight.FlightNumber);
            var bindingList = new BindingList<Passenger>(passengerList);
            var source = new BindingSource(bindingList, null);
            dataGridViewPassenger.DataSource = null;
            dataGridViewPassenger.DataSource = source;
        }

        private void AdjustColumnOrderCrew()
        {
            dataGridViewCrews.Columns["FlightCarrier"].Visible = false;
            dataGridViewCrews.Columns["PersonId"].Visible = false;
            dataGridViewCrews.Columns["DateOfBirth"].Visible = false;
            dataGridViewCrews.Columns["PersonType"].Visible = false;
            dataGridViewCrews.Columns["PassportNo"].DisplayIndex = 1;
            dataGridViewCrews.Columns["PassportNo"].HeaderText = "Passport Number";
            dataGridViewCrews.Columns["FirstName"].HeaderText = "First Name";
            dataGridViewCrews.Columns["LastName"].HeaderText = "Last Name";

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

        private void buttonAddCrew_Click(object sender, EventArgs e)
        {
            AddCrewToFlightForm addCrewForm = new AddCrewToFlightForm(comboBoxCarrier.Text, this,user);
            addCrewForm.ShowDialog();
            if (!Object.ReferenceEquals(CrewListUpdate, null))
            {
                var bindingList = new BindingList<Crew>(CrewListUpdate);
                var source = new BindingSource(bindingList, null);
                dataGridViewCrews.DataSource = null;
                dataGridViewCrews.DataSource = source;
                AdjustColumnOrderCrew();
            }
            
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            comboBoxCarrier.Enabled = true;
            textBoxFlightNo.Enabled = true;
            textBoxOrigin.Enabled = true;
            textBoxDestination.Enabled = true;
            textBoxEconomySeat.Enabled = true;
            textBoxEconomyPlusSeat.Enabled = true;
            textBoxBusinessSeat.Enabled = true;
            textBoxEconomyPrice.Enabled = true;
            textBoxEconomyPlusPrice.Enabled = true;
            textBoxBusinessPrice.Enabled = true;
            buttonAddCrew.Enabled = true;
            dateTimePickerDeparture.Enabled = true;
            dateTimePickerArrival.Enabled = true;
            buttonSave.Enabled = true;
            buttonClear.Enabled = true;
            dataGridViewCrews.Enabled = true;

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxCarrier.SelectedIndex = 0;
            textBoxFlightNo.Text = "";
            textBoxOrigin.Text = "";
            textBoxDestination.Text = "";
            textBoxEconomySeat.Text = "";
            textBoxEconomyPlusSeat.Text = "";
            textBoxBusinessSeat.Text = "";
            textBoxEconomyPrice.Text = "";
            textBoxEconomyPlusPrice.Text = "";
            textBoxBusinessPrice.Text = "";
            dateTimePickerDeparture.Value = DateTime.Now;
            dateTimePickerArrival.Value = DateTime.Now.AddMinutes(1);
            dataGridViewCrews.DataSource = null; 
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string flightNo = textBoxFlightNo.Text;
            string origin = textBoxOrigin.Text;
            string destination = textBoxDestination.Text;
            string economySeat = textBoxEconomySeat.Text;
            string ecoPlusSeat = textBoxEconomyPlusSeat.Text;
            string businessSeat = textBoxBusinessSeat.Text;
            string ecoPrice = textBoxEconomyPrice.Text;
            string ecoPlusPrice = textBoxEconomyPlusPrice.Text;
            string businessPrice = textBoxBusinessPrice.Text;
            DateTime depart = dateTimePickerDeparture.Value;
            DateTime arrive = dateTimePickerArrival.Value;

            if (string.IsNullOrEmpty(flightNo) || flightNo.Trim().Equals("") ||
                string.IsNullOrEmpty(origin) || origin.Trim().Equals("") ||
                string.IsNullOrEmpty(destination) || destination.Trim().Equals("") ||
                string.IsNullOrEmpty(economySeat) || economySeat.Trim().Equals("") ||
                string.IsNullOrEmpty(ecoPlusSeat) || ecoPlusSeat.Trim().Equals("") ||
                string.IsNullOrEmpty(businessSeat) || businessSeat.Trim().Equals("") ||
                string.IsNullOrEmpty(ecoPrice) || ecoPrice.Trim().Equals("") ||
                string.IsNullOrEmpty(ecoPlusPrice) || ecoPlusPrice.Trim().Equals("") ||
                string.IsNullOrEmpty(businessPrice) || businessPrice.Trim().Equals(""))
            {
                MessageBox.Show("Please fill in all the fields", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ValidationHelper.UserEnterDouble(ecoPrice) && ValidationHelper.UserEnterDouble(businessPrice)
                    && ValidationHelper.UserEnterDouble(ecoPlusPrice) && ValidationHelper.UserEnterInteger(economySeat)
                    && ValidationHelper.UserEnterInteger(ecoPlusSeat) && ValidationHelper.UserEnterInteger(businessSeat)
                    && ValidationHelper.UserEnterAlphanumeric(flightNo) && ValidationHelper.UserEnterAlphabetStringWithSpace(origin)
                    && ValidationHelper.UserEnterAlphabetStringWithSpace(destination) && arrive>depart)
                {
                    if (origin.ToLower().Equals(destination.ToLower()))
                    {
                        MessageBox.Show("Please change origin or destination", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("Are you sure you want to update this flight?",
                "Airline Reservation System Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            flight.Price[TicketClass.Economy] = Convert.ToDouble(ecoPrice);
                            flight.Price[TicketClass.EconomyPlus] = Convert.ToDouble(ecoPlusPrice);
                            flight.Price[TicketClass.Business] = Convert.ToDouble(businessPrice);

                            flight.AvailableSeat[TicketClass.Economy] = Convert.ToInt32(economySeat);
                            flight.AvailableSeat[TicketClass.EconomyPlus] = Convert.ToInt32(ecoPlusSeat);
                            flight.AvailableSeat[TicketClass.Business] = Convert.ToInt32(businessSeat);

                            flight.FlightCarrier = carrierDAL.SearchCarrierByName(comboBoxCarrier.Text);
                            flight.FlightNumber = flightNo;
                            flight.Origin = origin;
                            flight.Destination = destination;
                            flight.DepartureTime = depart;
                            flight.ArrivalTime = arrive;

                            try
                            {
                                flightCrewDAL.DeleteFlightCrewFromFlightNumber(oldFlightNo);

                                flightDAL.UpdateFlight(flight, oldFlightNo);
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    if (flight.FlightNumber.ToLower().Equals(oldFlightNo.ToLower()))
                                    {
                                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated flight number: " + oldFlightNo, w);
                                    }
                                    else
                                    {
                                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated flight number: " + oldFlightNo+ " with new flight number: "+flight.FlightNumber, w);
                                    }
                                }

                                using (StreamReader r = File.OpenText("log.txt"))
                                {
                                    LogAppend.DumpLog(r);
                                }

                                if (!Object.ReferenceEquals(GetCrewFromDataGridCrew(), null))
                                {
                                    int i = 0;
                                    foreach (Crew c in GetCrewFromDataGridCrew())
                                    {
                                        flightCrewDAL.InsertNewAssignedFlightCrew(flight, c.PersonId);
                                        i++;
                                    }
                                    if (i > 0)
                                    {
                                        using (StreamWriter w = File.AppendText("log.txt"))
                                        {
                                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated flight crews in flight number: " + flight.FlightNumber, w);
                                        }

                                        using (StreamReader r = File.OpenText("log.txt"))
                                        {
                                            LogAppend.DumpLog(r);
                                        }
                                    }
                                }

                                this.Close();
                            }
                            catch (SqlException ex)
                            {
                                if (ex.Number == 2627)
                                {
                                    using (StreamWriter w = File.AppendText("log.txt"))
                                    {
                                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") attemped to update flight with duplicate data", w);
                                    }

                                    using (StreamReader r = File.OpenText("log.txt"))
                                    {
                                        LogAppend.DumpLog(r);
                                    }
                                    MessageBox.Show("Duplicate data", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else MessageBox.Show("Execute exception issue: " + ex.Message);
                            }
                            
                            
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid inputs", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void comboBoxCarrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oldCarrier.Name.Equals(comboBoxCarrier.Text) && Object.ReferenceEquals(CrewListUpdate, null))
            {
                var bindingList = new BindingList<Crew>(crewList);
                var source = new BindingSource(bindingList, null);
                dataGridViewCrews.DataSource = null;
                dataGridViewCrews.DataSource = source;
            }
            else if (oldCarrier.Name.Equals(comboBoxCarrier.Text) && !Object.ReferenceEquals(CrewListUpdate, null))
            {
                Crew crew = CrewListUpdate.First();
                if (crew.FlightCarrier.Name.Equals(comboBoxCarrier.Text))
                {
                    var bindingList = new BindingList<Crew>(CrewListUpdate);
                    var source = new BindingSource(bindingList, null);
                    dataGridViewCrews.DataSource = null;
                    dataGridViewCrews.DataSource = source;
                }
                else
                {
                    var bindingList = new BindingList<Crew>(crewList);
                    var source = new BindingSource(bindingList, null);
                    dataGridViewCrews.DataSource = null;
                    dataGridViewCrews.DataSource = source;
                }
            }
            else if (!oldCarrier.Name.Equals(comboBoxCarrier.Text) && Object.ReferenceEquals(CrewListUpdate, null))
            {
                dataGridViewCrews.DataSource = null;
            }
            else if (!oldCarrier.Name.Equals(comboBoxCarrier.Text) && !Object.ReferenceEquals(CrewListUpdate, null))
            {
                Crew crew = CrewListUpdate.First();
                if (crew.FlightCarrier.Name.Equals(comboBoxCarrier.Text))
                {
                    var bindingList = new BindingList<Crew>(CrewListUpdate);
                    var source = new BindingSource(bindingList, null);
                    dataGridViewCrews.DataSource = null;
                    dataGridViewCrews.DataSource = source;
                }
                else
                {
                    dataGridViewCrews.DataSource = null;
                }
            }
            
        }

        private List<Crew> GetCrewFromDataGridCrew()
        {
            List<Crew> crewList = new List<Crew>();
            foreach (DataGridViewRow row in dataGridViewCrews.Rows)
            {
                Crew crew = (Crew)row.DataBoundItem;
                crewList.Add(crew);
            }
            return crewList;
        }

        private void DataGridViewVisibleChanged(object sender, EventArgs e)
        {
            if (state ==0)
            {
                AdjustColumnOrderPassenger();
                EditPriceAndSeat();
                state++;
            }
        }
    }
}
