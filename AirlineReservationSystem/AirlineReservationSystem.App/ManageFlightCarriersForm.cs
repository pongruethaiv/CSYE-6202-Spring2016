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
    public partial class ManageFlightCarriersForm : Form
    {
        private User user;
        private CarrierDAL carrierDAL;
        private CrewDAL crewDAL;
        private FlightDAL flightDAL;
        private List<string> countryList;
        private List<Carrier> carrierList;

        public ManageFlightCarriersForm(User user)
        {
            this.user = user;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            carrierDAL = new CarrierDAL();
            flightDAL = new FlightDAL();
            crewDAL = new CrewDAL();
            countryList = new List<string>();
            carrierList = new List<Carrier>();
            LoadDataGridFlightCarriers();
            AddColumns();
            EditTotalFlightsAndCrews();
            AdjustColumnOrder();
            LoadFilterByComboBox();
            comboBoxFilter.SelectedIndex = 0;
        }

        private void LoadFilterByComboBox()
        {
            comboBoxFilter.Items.Add("All Countries");
            countryList = carrierDAL.GetCountryList();
            comboBoxFilter.Items.AddRange(countryList.Cast<object>().ToArray());
        }

        public void LoadDataGridFlightCarriers()
        {
            carrierList = carrierDAL.GetCarrierList();
            var bindingList = new BindingList<Carrier>(carrierList);
            var source = new BindingSource(bindingList, null);
            dataGridViewFlightCarriers.DataSource = null;
            dataGridViewFlightCarriers.DataSource = source;

            //DataGridViewColumn totalFlights = new DataGridViewColumn();
            //totalFlights.Name = "Total Flights";
            //dataGridViewFlightCarriers.Columns.Insert(2, totalFlights);

            //DataGridViewColumn totalCrews = new DataGridViewColumn();
            //totalCrews.Name = "Total Crews";
            //dataGridViewFlightCarriers.Columns.Insert(3, totalCrews);
            //AdjustColumnOrder();
        }

        private void AddColumns()
        {
            dataGridViewFlightCarriers.Columns.Add("TotalFlights", "Total Flights");
            dataGridViewFlightCarriers.Columns.Add("Crews", "No. of Crews");
        }

        private void AdjustColumnOrder()
        {
            dataGridViewFlightCarriers.Columns["Name"].DisplayIndex = 0;
            dataGridViewFlightCarriers.Columns["Country"].DisplayIndex = 1;
            dataGridViewFlightCarriers.Columns["TotalFlights"].DisplayIndex = 2;
            dataGridViewFlightCarriers.Columns["Crews"].DisplayIndex = 3;
        }

        private void EditTotalFlightsAndCrews()
        {
            dataGridViewFlightCarriers.Columns["TotalFlights"].ValueType = typeof(Int32);
            dataGridViewFlightCarriers.Columns["Crews"].ValueType = typeof(Int32);
            foreach (DataGridViewRow row in dataGridViewFlightCarriers.Rows)
            {
                var carrier = (Carrier)row.DataBoundItem;
                row.Cells["TotalFlights"].Value = flightDAL.GetTotalFlights(carrier.Name);
                row.Cells["Crews"].Value = crewDAL.GetTotalCrews(carrier.Name);
            }
        }

        private void buttonManageFlights_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageFlightsForm manageFlightForm = new ManageFlightsForm(user);
            manageFlightForm.ShowDialog();
            this.Close();
        }

        private void buttonManageCrew_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageFlightCrewsForm manageCrewForm = new ManageFlightCrewsForm(user);
            manageCrewForm.ShowDialog();
            this.Close();
        }

        private void buttonCreateFlightCarrier_Click(object sender, EventArgs e)
        {
            CreateNewFlightCarrierForm newCarrierForm = new CreateNewFlightCarrierForm(user);
            newCarrierForm.ShowDialog();
            LoadDataGridFlightCarriers();
            EditTotalFlightsAndCrews();
            AdjustColumnOrder();
            comboBoxFilter.Items.Clear();
            LoadFilterByComboBox();
            comboBoxFilter.SelectedIndex = 0;
        }

        private void buttonUpdateCarrier_Click(object sender, EventArgs e)
        {
            if (dataGridViewFlightCarriers.RowCount > 0)
            {
                Carrier carrier = (Carrier)dataGridViewFlightCarriers.CurrentRow.DataBoundItem;
                UpdateFlightCarrierForm updateCarrierForm = new UpdateFlightCarrierForm(carrier, user);
                updateCarrierForm.ShowDialog();
                LoadDataGridFlightCarriers();
                EditTotalFlightsAndCrews();
                AdjustColumnOrder();
                comboBoxFilter.Items.Clear();
                LoadFilterByComboBox();
                comboBoxFilter.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Please select a flight carrier to update", "Airline Reservation System Warning");
            }
        }

        private void buttonDeleteFlightCarrier_Click(object sender, EventArgs e)
        {
            if (dataGridViewFlightCarriers.RowCount > 0)
            {
                Carrier carrier = (Carrier)dataGridViewFlightCarriers.CurrentRow.DataBoundItem;
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this flight carrier?",
                "Airline Reservation System Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        carrierDAL.DeleteCarrier(carrier);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") deleted flight carrier: " + carrier.Name, w);
                        }

                        using (StreamReader r = File.OpenText("log.txt"))
                        {
                            LogAppend.DumpLog(r);
                        }
                        LoadDataGridFlightCarriers();
                        EditTotalFlightsAndCrews();
                        AdjustColumnOrder();
                        comboBoxFilter.Items.Clear();
                        LoadFilterByComboBox();
                        comboBoxFilter.SelectedIndex = 0;
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
            if (comboBoxFilter.SelectedIndex == 0)
            {
                carrierList = carrierDAL.GetCarrierList();
            }
            else
            {
                carrierList = carrierDAL.SearchCarrierListByCountry(comboBoxFilter.Text);
            }
            var bindingList = new BindingList<Carrier>(carrierList);
            var source = new BindingSource(bindingList, null);
            dataGridViewFlightCarriers.DataSource = null;
            dataGridViewFlightCarriers.DataSource = source;
            EditTotalFlightsAndCrews();
            AdjustColumnOrder();
        }

        private void DataGridViewVisibleChanged(object sender, EventArgs e)
        {
            EditTotalFlightsAndCrews();
        }
    }
}
