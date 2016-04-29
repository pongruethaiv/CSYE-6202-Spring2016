using AirlineReservationSystem.DAL;
using AirlineReservationSystem.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservationSystem.App
{
    public partial class SearchFlightForm : Form
    {
        private User user;
        private FlightCrewDAL flightCrewDAL;
        private List<Flight> flightList;
        private CarrierDAL carrierDAL;
        private FlightDAL flightDAL;
        private List<Carrier> carrierList;

        public SearchFlightForm(User user)
        {
            InitializeComponent();
            this.user = user;
            Init();
        }

        private void Init()
        {
            carrierDAL = new CarrierDAL();
            flightDAL = new FlightDAL();
            flightCrewDAL = new FlightCrewDAL();
            LoadComboBoxCarrier();
            LoadComboBoxOrigin();
            LoadComboBoxDestination();
            dateTimePickerDepart.Value = DateTime.Now;
            dateTimePickerDepart.ShowUpDown = true;
            dateTimePickerDepart.Format = DateTimePickerFormat.Custom;
            dateTimePickerDepart.CustomFormat = "ddd dd MMMM yyyy hh:mm tt";
            AddColumns();
            LoadDataGridFlights();
        }

        private void LoadComboBoxCarrier()
        {
            comboBoxCarrier.Items.Add(String.Empty);
            carrierList = carrierDAL.GetCarrierList();

            foreach (Carrier c in carrierList)
            {
                comboBoxCarrier.Items.Add(c.Name);
            }
            comboBoxCarrier.SelectedIndex = 0;
        }

        private void AddColumns()
        {
            dataGridViewFlights.Columns.Add("Available", "Available Seats");
            dataGridViewFlights.Columns.Add("Crews", "No. of Crews");
        }

        private void EditSeatAndPriceInDataGridView()
        {
            dataGridViewFlights.Columns["Available"].ValueType = typeof(Int32);
            dataGridViewFlights.Columns["Crews"].ValueType = typeof(Int32);
            foreach (DataGridViewRow row in dataGridViewFlights.Rows)
            {
                var flight = (Flight)row.DataBoundItem;
                if (!Object.ReferenceEquals(flight, null))
                {
                    int availableSeat = flight.AvailableSeat[TicketClass.Economy] + flight.AvailableSeat[TicketClass.EconomyPlus]
                    + flight.AvailableSeat[TicketClass.Business];
                    int crew = flightCrewDAL.GetNoOfCrewFromFlightNumber(flight.FlightNumber);
                    row.Cells["Available"].Value = availableSeat;
                    row.Cells["Crews"].Value = crew;
                }

            }
        }

        private void LoadComboBoxOrigin()
        {
            comboBoxOrigin.Items.Add(String.Empty);
            foreach (string s in flightDAL.GetOriginList())
            {
                comboBoxOrigin.Items.Add(s);
            }
            comboBoxOrigin.SelectedIndex = 0;
        }

        private void LoadComboBoxDestination()
        {
            comboBoxDestination.Items.Add(String.Empty);
            foreach (string s in flightDAL.GetDestinationList())
            {
                comboBoxDestination.Items.Add(s);
            }
            comboBoxDestination.SelectedIndex = 0;
        }

        public void LoadDataGridFlights()
        {
            flightList = flightDAL.GetFlightList();
            var bindingList = new BindingList<Flight>(flightList);
            var source = new BindingSource(bindingList, null);
            dataGridViewFlights.DataSource = null;
            dataGridViewFlights.DataSource = source;
            EditSeatAndPriceInDataGridView();
            AdjustColumnOrder();
        }

        private void AdjustColumnOrder()
        {
            dataGridViewFlights.Columns["FlightCarrier"].HeaderText = "Carrier";
            dataGridViewFlights.Columns["FlightNumber"].HeaderText = "Flight Number";
            dataGridViewFlights.Columns["DepartureTime"].HeaderText = "Departure Date";
            dataGridViewFlights.Columns["ArrivalTime"].HeaderText = "Arrival Date";
            dataGridViewFlights.Columns["AvailableSeat"].Visible = false;
            dataGridViewFlights.Columns["Price"].Visible = false;

            dataGridViewFlights.Columns["FlightCarrier"].DisplayIndex = 0;
            dataGridViewFlights.Columns["FlightNumber"].DisplayIndex = 1;
            dataGridViewFlights.Columns["Origin"].DisplayIndex = 2;
            dataGridViewFlights.Columns["Destination"].DisplayIndex = 3;
            dataGridViewFlights.Columns["DepartureTime"].DisplayIndex = 4;
            dataGridViewFlights.Columns["ArrivalTime"].DisplayIndex = 5;
            dataGridViewFlights.Columns["Available"].DisplayIndex = 6;
            dataGridViewFlights.Columns["Crews"].DisplayIndex = 7;
        }

        private void buttonViewDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewFlights.RowCount > 0)
            {
                Flight flight = (Flight)dataGridViewFlights.CurrentRow.DataBoundItem;
                ViewFlightDetailsForm viewFlightForm = new ViewFlightDetailsForm(flight, carrierList, user);
                viewFlightForm.ShowDialog();
                LoadDataGridFlights();
            }
            else
            {
                MessageBox.Show("Please select a flight to view details", "Airline Reservation System Warning");
            }
        }

        private void buttonShowFlights_Click(object sender, EventArgs e)
        {
            LoadDataGridFlights();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string flightNo = textBoxFlightNo.Text;
            string origin = comboBoxOrigin.Text;
            string destination = comboBoxDestination.Text;
            string carrier = comboBoxCarrier.Text;
            string depart = dateTimePickerDepart.Value.ToString("yyyyMMddhhmmtt");

            if ( (string.IsNullOrEmpty(flightNo) || flightNo.Trim().Equals("")) &&
                (string.IsNullOrEmpty(origin) || origin.Trim().Equals("")) &&
                (string.IsNullOrEmpty(destination) || destination.Trim().Equals("")) &&
                (string.IsNullOrEmpty(carrier) || carrier.Trim().Equals("")) &&
                !dateTimePickerDepart.Enabled)
            {
                MessageBox.Show("Please fill out information", "Airline Reservation System Warning");
            }
            else if(!dateTimePickerDepart.Enabled)
            {
                //1
                if (!string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumber(flightNo);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            flightList.Add(flight);
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //2
                else if (string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                    string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.GetFlightListFromOrigin(origin);
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //4
                else if (string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                    !string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.GetFlightListFromDestination(destination);
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //5
                else if (string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                    string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.GetFlightListFromCarrierName(carrier);
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //1,2
                else if (!string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndOrigin(flightNo, origin);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            flightList.Add(flight);
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //1,4
                else if (!string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndDestination(flightNo, destination);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            flightList.Add(flight);
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //1,5
                else if (!string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndCarrier(flightNo, carrier);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            flightList.Add(flight);
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //2,4
                else if (string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                    !string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    flightList = new List<Flight>();
                    Flight flight = flightDAL.SearchFlightByOriginAndDestination(origin, destination);
                    if (!Object.ReferenceEquals(flight, null))
                    {
                        flightList.Add(flight);
                    }
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //2,5
                else if (string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                    string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.SearchFlightByOriginAndCarrierName(origin, carrier);
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //4,5
                else if (string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                    !string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.SearchFlightByDestinationAndCarrierName(destination, carrier);
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //1,2,4
                else if (!string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndOriginAndDestination(flightNo, origin, destination);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            flightList.Add(flight);
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //1,2,5
                else if (!string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndOriginAndCarrierName(flightNo, origin, carrier);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            flightList.Add(flight);
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //1,4,5
                else if (!string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndDestinationAndCarrierName(flightNo, destination, carrier);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            flightList.Add(flight);
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //2,4,5
                else if (string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                    !string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    flightList = new List<Flight>();
                    Flight flight = flightDAL.SearchFlightByOriginAndDestinationAndCarrierName(origin, destination, carrier);
                    if (!Object.ReferenceEquals(flight, null))
                    {
                        flightList.Add(flight);
                    }
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //1,2,4,5
                else if (!string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndOriginAndDestinationAndCarrierName(flightNo, origin, destination, carrier);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            flightList.Add(flight);
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
            }
            else if (dateTimePickerDepart.Enabled)
            {
                //1
                if (!string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        flightList = new List<Flight>();
                        Flight flight = flightDAL.SearchFlightByFlightNumber(flightNo);
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                            {
                                flightList.Add(flight);
                            }
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //2
                else if (string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                    string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.GetFlightListFromOrigin(origin);
                    var newList = new List<Flight>();
                    foreach (Flight flight in flightList)
                    {
                        if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                        {
                            newList.Add(flight);
                        }
                    }
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = newList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //4
                else if (string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                    !string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.GetFlightListFromDestination(destination);
                    var newList = new List<Flight>();
                    foreach (Flight flight in flightList)
                    {
                        if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                        {
                            newList.Add(flight);
                        }
                    }
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = newList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //5
                else if (string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                    string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.GetFlightListFromCarrierName(carrier);
                    var newList = new List<Flight>();
                    foreach (Flight flight in flightList)
                    {
                        if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                        {
                            newList.Add(flight);
                        }
                    }
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = newList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //1,2
                else if (!string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndOrigin(flightNo, origin);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                            {
                                flightList.Add(flight);
                            }
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //1,4
                else if (!string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndDestination(flightNo, destination);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                            {
                                flightList.Add(flight);
                            }
                        }
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //1,5
                else if (!string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndCarrier(flightNo, carrier);
                        flightList = new List<Flight>();
                        if (!Object.ReferenceEquals(flight, null))
                        {
                            if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                            {
                                flightList.Add(flight);
                            }
                        }
                            
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //2,4
                else if (string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                    !string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    flightList = new List<Flight>();
                    Flight flight = flightDAL.SearchFlightByOriginAndDestination(origin, destination);
                    if (!object.ReferenceEquals(flight, null))
                    {
                        if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                        {
                            flightList.Add(flight);
                        }
                    }
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();

                }
                //2,5
                else if (string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                    string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.SearchFlightByOriginAndCarrierName(origin, carrier);
                    var newList = new List<Flight>();
                    foreach (Flight flight in flightList)
                    {
                        if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                        {
                            newList.Add(flight);
                        }
                    }
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = newList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //4,5
                else if (string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                    !string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    flightList = flightDAL.SearchFlightByDestinationAndCarrierName(destination, carrier);
                    var newList = new List<Flight>();
                    foreach (Flight flight in flightList)
                    {
                        if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                        {
                            newList.Add(flight);
                        }
                    }
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = newList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //1,2,4
                else if (!string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destination) && string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndOriginAndDestination(flightNo, origin, destination);
                        flightList = new List<Flight>();
                        if (!object.ReferenceEquals(flight, null))
                        {
                            if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                            {
                                flightList.Add(flight);
                            }
                        }
                            
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //1,2,5
                else if (!string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndOriginAndCarrierName(flightNo, origin, carrier);
                        flightList = new List<Flight>();
                        if (!object.ReferenceEquals(flight, null))
                        {
                            if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                            {
                                flightList.Add(flight);
                            }
                        }
                            
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //1,4,5
                else if (!string.IsNullOrEmpty(flightNo) && string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndDestinationAndCarrierName(flightNo, destination, carrier);
                        flightList = new List<Flight>();
                        if (!object.ReferenceEquals(flight, null))
                        {
                            if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                            {
                                flightList.Add(flight);
                            }
                        }
                            
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //2,4,5
                else if (string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                    !string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    flightList = new List<Flight>();
                    Flight flight = flightDAL.SearchFlightByOriginAndDestinationAndCarrierName(origin, destination, carrier);
                    if (!object.ReferenceEquals(flight, null))
                    {
                        if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                        {
                            flightList.Add(flight);
                        }
                    }
                        
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = flightList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
                //1,2,4,5
                else if (!string.IsNullOrEmpty(flightNo) && !string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destination) && !string.IsNullOrEmpty(carrier))
                {
                    if (ValidationHelper.UserEnterAlphanumeric(flightNo))
                    {
                        Flight flight = flightDAL.SearchFlightByFlightNumberAndOriginAndDestinationAndCarrierName(flightNo, origin, destination, carrier);
                        flightList = new List<Flight>();
                        if (!object.ReferenceEquals(flight, null))
                        {
                            if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                            {
                                flightList.Add(flight);
                            }
                        }
                            
                        dataGridViewFlights.DataSource = null;
                        dataGridViewFlights.DataSource = flightList;
                        EditSeatAndPriceInDataGridView();
                        AdjustColumnOrder();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Flight Number", "Airline Reservation System Warning");
                    }
                }
                //only date
                else {
                    flightList = flightDAL.GetFlightList();
                    var newList = new List<Flight>();
                    foreach (Flight flight in flightList)
                    {
                        if (flight.DepartureTime.ToString("yyyyMMddhhmmtt") == depart)
                        {
                            newList.Add(flight);
                        }
                    }
                    
                    dataGridViewFlights.DataSource = null;
                    dataGridViewFlights.DataSource = newList;
                    EditSeatAndPriceInDataGridView();
                    AdjustColumnOrder();
                }
            }
        }

        private void buttonEnableDeparture_Click(object sender, EventArgs e)
        {
            if (dateTimePickerDepart.Enabled)
            {
                dateTimePickerDepart.Enabled = false;
            }
            else dateTimePickerDepart.Enabled = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxCarrier.SelectedIndex = 0;
            comboBoxDestination.SelectedIndex = 0;
            comboBoxOrigin.SelectedIndex = 0;
            textBoxFlightNo.Text = string.Empty;
            dateTimePickerDepart.Value = DateTime.Now;
        }

        private void dataGridViewVisibleChanged(object sender, EventArgs e)
        {
            EditSeatAndPriceInDataGridView();
        }
    }
}
