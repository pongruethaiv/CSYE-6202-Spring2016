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
    public partial class AssignFlightToCrewForm : Form
    {
        private User user;
        private List<Flight> flightList;
        private List<Flight> oldFlightList;
        private FlightDAL flightDAL;
        private ViewUpdateFlightCrewDetailsForm form;
        private string carrierName;

        public AssignFlightToCrewForm(List<Flight> oldFlightList, string carrierName, ViewUpdateFlightCrewDetailsForm form, User user)
        {
            InitializeComponent();
            this.user = user;
            this.carrierName = carrierName;
            this.form = form;
            this.oldFlightList = oldFlightList;
            Init();
        }

        private void Init()
        {
            flightDAL = new FlightDAL();
            LoadDataGridFlights();
        }

        public void LoadDataGridFlights()
        {
            flightList = flightDAL.GetFlightListFromCarrierName(carrierName);
            var bindingList = new BindingList<Flight>(flightList);
            var source = new BindingSource(bindingList, null);
            dataGridViewFlights.DataSource = null;
            dataGridViewFlights.DataSource = source;
            AddCheckBoxColumnToDataGrid();
            AdjustColumnOrder();
        }

        private void AdjustColumnOrder()
        {
            dataGridViewFlights.Columns["FlightCarrier"].Visible = false;
            dataGridViewFlights.Columns["Price"].Visible = false;
            dataGridViewFlights.Columns["AvailableSeat"].Visible = false;
            dataGridViewFlights.Columns["checkBoxColumn"].DisplayIndex = 0;
            dataGridViewFlights.Columns["FlightNumber"].DisplayIndex = 1;
            dataGridViewFlights.Columns["Origin"].DisplayIndex = 2;
            dataGridViewFlights.Columns["Destination"].DisplayIndex = 3;
            dataGridViewFlights.Columns["DepartureTime"].DisplayIndex = 4;
            dataGridViewFlights.Columns["ArrivalTime"].DisplayIndex = 5;
            dataGridViewFlights.Columns["FlightNumber"].HeaderText = "Flight Number";
            dataGridViewFlights.Columns["DepartureTime"].HeaderText = "Departure Time";
            dataGridViewFlights.Columns["ArrivalTime"].HeaderText = "Arrival Time";
            //dataGridViewFlights.Columns["DepartureTime"].Width = 30;
            //dataGridViewFlights.Columns["ArrivalTime"].Width = 30;

            //foreach (Flight f in oldFlightList)
            //{
            //    foreach (DataGridViewRow row in dataGridViewFlights.Rows)
            //    {
            //        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
            //        if (row.Cells["FlightNumber"].Value.Equals(f.FlightNumber))
            //        {
            //            Console.WriteLine(row.Cells["checkBoxColumn"].Value);
            //            chk.Value = chk.TrueValue;
            //            //row.Cells["checkBoxColumn"].Value = true;
            //            Console.WriteLine(row.Cells["checkBoxColumn"].Value);
            //        }
            //    }
            //}
        }

        private void AddCheckBoxColumnToDataGrid()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Width = 20;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridViewFlights.Columns.Insert(0, checkBoxColumn);
        }

        private List<Flight> GetFlightFromDataGridCrew()
        {
            List<Flight> flightList = new List<Flight>();
            foreach (DataGridViewRow row in dataGridViewFlights.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    Flight flight = (Flight)row.DataBoundItem;
                    flightList.Add(flight);
                }
            }
            return flightList;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            flightList = GetFlightFromDataGridCrew();
            form.newFlightList = flightList;
            this.Close();
        }
    }
}
