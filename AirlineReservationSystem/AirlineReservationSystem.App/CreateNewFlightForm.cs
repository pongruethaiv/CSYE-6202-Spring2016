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
    public partial class CreateNewFlightForm : Form
    {
        private User user;
        private FlightDAL flightDAL;
        private FlightCrewDAL flightCrewDAL;
        private CarrierDAL carrierDAL;
        private CrewDAL crewDAL;
        private List<Crew> crewList;

        public CreateNewFlightForm(User user)
        {
            this.user = user;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            flightDAL = new FlightDAL();
            flightCrewDAL = new FlightCrewDAL();
            carrierDAL = new CarrierDAL();
            crewDAL = new CrewDAL();
            LoadComboBoxCarrier();
            LoadDefault();
        }

        private void LoadDefault()
        {
            dateTimePickerDeparture.ShowUpDown = true;
            dateTimePickerDeparture.Format = DateTimePickerFormat.Custom;
            dateTimePickerDeparture.CustomFormat = "ddd dd MMMM yyyy hh:mm tt";
            dateTimePickerArrival.Format = DateTimePickerFormat.Custom;
            dateTimePickerArrival.ShowUpDown = true;
            dateTimePickerArrival.CustomFormat = "ddd dd MMMM yyyy hh:mm tt";
            dateTimePickerArrival.Value = DateTime.Now.AddMinutes(1);
            if (comboBoxCarrier.Items.Count > 0)
            {
                comboBoxCarrier.SelectedIndex = 0;
                LoadDatagridCrew(comboBoxCarrier.Text);
                AddCheckBoxColumnToDataGrid();
                AdjustColumnOrder();
            }
            
        }

        private void LoadDatagridCrew(string carrierName)
        {
            Carrier c = carrierDAL.SearchCarrierByName(carrierName);
            crewList = crewDAL.getCrewListFromCarrier(c);
            var bindingList = new BindingList<Crew>(crewList);
            var source = new BindingSource(bindingList, null);
            dataGridViewCrews.DataSource = null;
            dataGridViewCrews.DataSource = source;
        }

        private void AddCheckBoxColumnToDataGrid()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridViewCrews.Columns.Insert(0, checkBoxColumn);
        }

        private void AdjustColumnOrder()
        {
            dataGridViewCrews.Columns["FlightCarrier"].Visible = false;
            dataGridViewCrews.Columns["PersonId"].Visible = false;
            dataGridViewCrews.Columns["DateOfBirth"].Visible = false;
            dataGridViewCrews.Columns["PersonType"].Visible = false;
            dataGridViewCrews.Columns["PassportNo"].DisplayIndex = 1;
            dataGridViewCrews.Columns["PassportNo"].HeaderText = "Passport Number";
            dataGridViewCrews.Columns["FirstName"].HeaderText = "First Name";
            dataGridViewCrews.Columns["LastName"].HeaderText = "Last Name";
            //dataGridViewCrews.Columns["FirstName"].DisplayIndex = 2;
            //dataGridViewCrews.Columns["LastName"].DisplayIndex = 3;
            //dataGridViewCrews.Columns["Nationality"].DisplayIndex = 4;
            //dataGridViewCrews.Columns["Gender"].DisplayIndex = 5;
        }

        private void LoadComboBoxCarrier()
        {
            foreach (Carrier c in carrierDAL.GetCarrierList())
            {
                comboBoxCarrier.Items.Add(c.Name);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewCrews.Rows)
            {
                row.Cells["checkBoxColumn"].Value = false;
            }
            textBoxFlightNo.Text = "";
            textBoxOrigin.Text = "";
            textBoxDestination.Text = "";
            textBoxEconomySeat.Text = "";
            textBoxEconomyPlusSeat.Text = "";
            textBoxBusinessSeat.Text = "";
            textBoxEconomyPrice.Text = "";
            textBoxEconomyPlusPrice.Text = "";
            textBoxBusinessPrice.Text = "";
            if (comboBoxCarrier.Items.Count > 0)
            {
                comboBoxCarrier.SelectedIndex = 0;
            }
            dateTimePickerDeparture.Value = DateTime.Now;
            dateTimePickerArrival.Value = DateTime.Now.AddMinutes(1);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
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
                string.IsNullOrEmpty(businessPrice) || businessPrice.Trim().Equals("") ||
                comboBoxCarrier.Items.Count == 0)
            {
                MessageBox.Show("Please fill in all the fields", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ValidationHelper.UserEnterDouble(ecoPrice) && ValidationHelper.UserEnterDouble(businessPrice)
                    && ValidationHelper.UserEnterDouble(ecoPlusPrice) && ValidationHelper.UserEnterInteger(economySeat)
                    && ValidationHelper.UserEnterInteger(ecoPlusSeat) && ValidationHelper.UserEnterInteger(businessSeat)
                    && ValidationHelper.UserEnterAlphanumeric(flightNo) && ValidationHelper.UserEnterAlphabetStringWithSpace(origin)
                    && ValidationHelper.UserEnterAlphabetStringWithSpace(destination) && arrive > depart) 
                {
                    if (origin.ToLower().Equals(destination.ToLower()))
                    {
                        MessageBox.Show("Please change origin or destination", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Dictionary<string, double> seatPrice = new Dictionary<string, double>()
                        {
                            { TicketClass.Economy, Convert.ToDouble(ecoPrice)},
                            { TicketClass.EconomyPlus, Convert.ToDouble(ecoPlusPrice)},
                            { TicketClass.Business, Convert.ToDouble(businessPrice)}
                        };
                        Dictionary<string, int> availSeat = new Dictionary<string, int>()
                        {
                            { TicketClass.Economy, Convert.ToInt32(economySeat)},
                            { TicketClass.EconomyPlus, Convert.ToInt32(ecoPlusSeat)},
                            { TicketClass.Business, Convert.ToInt32(businessSeat)}
                        };

                        Flight flight = new Flight()
                        {
                            FlightCarrier = carrierDAL.SearchCarrierByName(comboBoxCarrier.Text),
                            FlightNumber = flightNo,
                            Origin = origin,
                            Destination = destination,
                            DepartureTime = depart,
                            ArrivalTime = arrive,
                            //Booking = new List<Ticket>(),
                            //CrewList = new List<Crew>(), //get from data grid
                            //PassengerList = new List<Passenger>(),
                            Price = seatPrice,
                            AvailableSeat = availSeat
                        };

                        try
                        {
                            flightDAL.InsertNewFlight(flight);
                            var cList = GetCrewFromDataGridCrew();
                            int size = cList.Count();
                            foreach (Crew c in cList)
                            {
                                flightCrewDAL.InsertNewAssignedFlightCrew(flight, c.PersonId);
                            }
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                LogAppend.Log("(" + user.Role + ": " + user.Username + ") created new flight number: "+flight.FlightNumber, w);
                                if (size>0)
                                {
                                    LogAppend.Log("(" + user.Role + ": " + user.Username + ") added flight crews to flight number: "+flight.FlightNumber, w);
                                }
                            }

                            using (StreamReader r = File.OpenText("log.txt"))
                            {
                                LogAppend.DumpLog(r);
                            }
                            this.Close();
                        }
                        catch (SqlException ex)
                        {
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                if (ex.Number == 2627)
                                {
                                    LogAppend.Log("(" + user.Role + ": " + user.Username + ") attemped to create new flight with duplicate data", w);
                                    MessageBox.Show("Duplicate data", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    LogAppend.Log("(" + user.Role + ": " + user.Username + ") exception occured: " + ex.Message, w);
                                    MessageBox.Show("Execute exception issue: " + ex.Message);
                                }
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
                    MessageBox.Show("Invalid inputs", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
                
        }

        private List<Crew> GetCrewFromDataGridCrew()
        {
            List<Crew> crewList = new List<Crew>();
            foreach (DataGridViewRow row in dataGridViewCrews.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    Crew crew = (Crew)row.DataBoundItem;
                    crewList.Add(crew);
                    //crewPassport.Add(row.Cells["PassportNo"].Value.ToString());
                }
            }
            return crewList;
        }

        private void comboBoxCarrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDatagridCrew(comboBoxCarrier.Text);
            AdjustColumnOrder();
        }
    }
}
