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
    public partial class ManageFlightsForm : Form
    {
        private User user;
        private List<Flight> flightList;
        private FlightDAL flightDAL;
        private FlightCrewDAL flightCrewDAL;
        BindingSource source;

        public ManageFlightsForm(User user)
        {
            InitializeComponent();
            this.user = user;
            Init();
        }

        private void Init()
        {
            flightDAL = new FlightDAL();
            flightCrewDAL = new FlightCrewDAL();
            LoadFilterByComboBox();
            LoadDataGridFlights();
            AdjustColumnOrder();
            comboBoxFilter.SelectedIndex = 0;
        }

        private void LoadFilterByComboBox()
        {
            string[] filterBy = new[] { "All Flights", "Future Flights", "Past Flights" };
            comboBoxFilter.Items.AddRange(filterBy);
        }

        public void LoadDataGridFlights()
        {
            flightList = flightDAL.GetFlightList();
            var bindingList = new BindingList<Flight>(flightList);
            source = new BindingSource(bindingList, null);
            dataGridViewFlights.DataSource = null;
            dataGridViewFlights.DataSource = source;
            AddColumns();
            AdjustDatagrid();
        }

        public void LoadDataGridFlightsWithoutAddingColumns()
        {
            flightList = flightDAL.GetFlightList();
            var bindingList = new BindingList<Flight>(flightList);
            source = new BindingSource(bindingList, null);
            dataGridViewFlights.DataSource = null;
            dataGridViewFlights.DataSource = source;
            AdjustDatagrid();
            AdjustColumnOrder();
        }

        private void AdjustDatagrid()
        {
            EditSeatAndPriceInDataGridView();
            dataGridViewFlights.Columns["FlightCarrier"].HeaderText = "Carrier";
            dataGridViewFlights.Columns["FlightNumber"].HeaderText = "Flight Number";
            dataGridViewFlights.Columns["DepartureTime"].HeaderText = "Departure Date";
            dataGridViewFlights.Columns["ArrivalTime"].HeaderText = "Arrival Date";
            dataGridViewFlights.Columns["AvailableSeat"].Visible = false;
            dataGridViewFlights.Columns["Price"].Visible = false;
        }

        private void AddColumns()
        {
            dataGridViewFlights.Columns.Add("Available", "Available Seats");
            dataGridViewFlights.Columns.Add("Crews", "No. of Crews");
        }

        private void AdjustColumnOrder()
        {
            dataGridViewFlights.Columns["FlightCarrier"].DisplayIndex = 0;
            dataGridViewFlights.Columns["FlightNumber"].DisplayIndex = 1;
            dataGridViewFlights.Columns["Origin"].DisplayIndex = 2;
            dataGridViewFlights.Columns["Destination"].DisplayIndex = 3;
            dataGridViewFlights.Columns["DepartureTime"].DisplayIndex = 4;
            dataGridViewFlights.Columns["ArrivalTime"].DisplayIndex = 5;
            dataGridViewFlights.Columns["Available"].DisplayIndex = 6;
            dataGridViewFlights.Columns["Crews"].DisplayIndex = 7;
        }

        private void EditSeatAndPriceInDataGridView()
        {
            dataGridViewFlights.Columns["Available"].ValueType = typeof(Int32);
            dataGridViewFlights.Columns["Crews"].ValueType = typeof(Int32);
            foreach (DataGridViewRow row in dataGridViewFlights.Rows)
            {
                var flight = (Flight)row.DataBoundItem;
                int availableSeat = flight.AvailableSeat[TicketClass.Economy]+flight.AvailableSeat[TicketClass.EconomyPlus]
                    +flight.AvailableSeat[TicketClass.Business];
                int crew = flightCrewDAL.GetNoOfCrewFromFlightNumber(flight.FlightNumber);
                row.Cells["Available"].Value = availableSeat;
                row.Cells["Crews"].Value = crew;
            }
        }

        private void buttonCreateFlight_Click(object sender, EventArgs e)
        {
            CreateNewFlightForm createFlightForm = new CreateNewFlightForm(user);
            createFlightForm.ShowDialog();
            LoadDataGridFlightsWithoutAddingColumns();
        }

        private void buttonViewUpdateFlight_Click(object sender, EventArgs e)
        {
            if (dataGridViewFlights.RowCount > 0)
            {
                Flight flight = (Flight)dataGridViewFlights.CurrentRow.DataBoundItem;
                ViewUpdateFlightDetailsForm viewUpdateForm = new ViewUpdateFlightDetailsForm(flight, user);
                viewUpdateForm.ShowDialog();
                LoadDataGridFlightsWithoutAddingColumns();
            }
            else
            {
                MessageBox.Show("Please select a flight to update", "Airline Reservation System Warning");
            }
        }

        private void buttonManageCarrier_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageFlightCarriersForm manageCarrierForm = new ManageFlightCarriersForm(user);
            manageCarrierForm.ShowDialog();
            this.Close();
        }

        private void buttonManageCrew_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageFlightCrewsForm manageCrewForm = new ManageFlightCrewsForm(user);
            manageCrewForm.ShowDialog();
            this.Close();
        }

        private void buttonDeleteFlight_Click(object sender, EventArgs e)
        {
            if (dataGridViewFlights.RowCount > 0)
            {
                Flight flight = (Flight)dataGridViewFlights.CurrentRow.DataBoundItem;
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this flight?",
                "Airline Reservation System Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        string delete = flight.FlightNumber;
                        FlightDAL flightDAL = new FlightDAL();
                        flightCrewDAL.DeleteFlightCrewFromFlightNumber(flight.FlightNumber);
                        flightDAL.DeleteFlights(flight);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") deleted flight with flight number: " + delete, w);
                        }

                        using (StreamReader r = File.OpenText("log.txt"))
                        {
                            LogAppend.DumpLog(r);
                        }
                        LoadDataGridFlightsWithoutAddingColumns();
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
                MessageBox.Show("Please select a flight carrier to delete", "Airline Reservation System Warning");
            }
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFilter.Text.Equals("All Flights"))
            {
                var bindingList = new BindingList<Flight>(flightList);
                var source = new BindingSource(bindingList, null);
                dataGridViewFlights.DataSource = null;
                dataGridViewFlights.DataSource = source;
                AdjustDatagrid();
                AdjustColumnOrder();
            }
            else if (comboBoxFilter.Text.Equals("Future Flights"))
            {
                List<Flight> futureList = new List<Flight>();
                foreach (Flight f in flightList)
                {
                    int result = DateTime.Compare(DateTime.Now, f.ArrivalTime);
                    if (result <= 0)
                    {
                        futureList.Add(f);
                    }
                }
                var bindingList = new BindingList<Flight>(futureList);
                var source = new BindingSource(bindingList, null);
                dataGridViewFlights.DataSource = null;
                dataGridViewFlights.DataSource = source;
                AdjustDatagrid();
                AdjustColumnOrder();
            }
            else
            {
                List<Flight> pastList = new List<Flight>();
                foreach (Flight f in flightList)
                {
                    int result = DateTime.Compare(DateTime.Now, f.ArrivalTime);
                    if (result > 0)
                    {
                        pastList.Add(f);
                    }
                }
                var bindingList = new BindingList<Flight>(pastList);
                var source = new BindingSource(bindingList, null);
                dataGridViewFlights.DataSource = null;
                dataGridViewFlights.DataSource = source;
                AdjustDatagrid();
                AdjustColumnOrder();
            }
        }

        private void DataGridVisibleChanged(object sender, EventArgs e)
        {
            LoadDataGridFlightsWithoutAddingColumns();
        }
    }
}
