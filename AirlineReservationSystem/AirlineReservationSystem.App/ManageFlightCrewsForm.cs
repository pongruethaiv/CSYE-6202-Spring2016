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
    public partial class ManageFlightCrewsForm : Form
    {
        private User user;
        private CrewDAL crewDAL;
        private CarrierDAL carrierDAL;
        private List<Crew> crewList;
        private List<Carrier> carrierList;
        private FlightCrewDAL flightCrewDAL;

        public ManageFlightCrewsForm(User user)
        {
            this.user = user;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            crewDAL = new CrewDAL();
            carrierDAL = new CarrierDAL();
            flightCrewDAL = new FlightCrewDAL();
            carrierList = carrierDAL.GetCarrierList();
            LoadDataGridCrews();
            LoadFilterByComboBox();
            comboBoxFilter.SelectedIndex = 0;
        }

        private void LoadFilterByComboBox()
        {
            comboBoxFilter.Items.Add("All Carriers");
            comboBoxFilter.Items.AddRange(carrierList.Cast<object>().ToArray());
        }

        public void LoadDataGridCrews()
        {
            crewList = crewDAL.getCrewList();
            var bindingList = new BindingList<Crew>(crewList);
            var source = new BindingSource(bindingList, null);
            dataGridViewFlightCrews.DataSource = null;
            dataGridViewFlightCrews.DataSource = source;
            AddColumns();
            AdjustDatagrid();
            
        }

        public void RefreshDataGridCrews()
        {
            dataGridViewFlightCrews.DataSource = null;
            crewList = crewDAL.getCrewList();
            var bindingList = new BindingList<Crew>(crewList);
            var source = new BindingSource(bindingList, null);
            dataGridViewFlightCrews.DataSource = source;
            AdjustDatagrid();
        }

        private void AdjustDatagrid()
        {
            dataGridViewFlightCrews.Columns["FlightCarrier"].DisplayIndex = 0;
            dataGridViewFlightCrews.Columns["PassportNo"].DisplayIndex = 1;
            dataGridViewFlightCrews.Columns["FirstName"].DisplayIndex = 2;
            dataGridViewFlightCrews.Columns["LastName"].DisplayIndex = 3;
            dataGridViewFlightCrews.Columns["DateOfBirth"].DisplayIndex = 4;
            dataGridViewFlightCrews.Columns["Gender"].DisplayIndex = 5;
            dataGridViewFlightCrews.Columns["Nationality"].DisplayIndex = 6;
            dataGridViewFlightCrews.Columns["TotalFlights"].DisplayIndex = 7;

            dataGridViewFlightCrews.Columns["PersonId"].Visible = false;
            dataGridViewFlightCrews.Columns["PersonType"].Visible = false;
            dataGridViewFlightCrews.Columns["FlightCarrier"].HeaderText = "Carrier";
            dataGridViewFlightCrews.Columns["PassportNo"].HeaderText = "Passport Number";
            dataGridViewFlightCrews.Columns["FirstName"].HeaderText = "First Name";
            dataGridViewFlightCrews.Columns["LastName"].HeaderText = "Last Name";
            dataGridViewFlightCrews.Columns["DateOfBirth"].HeaderText = "Date of Birth";
            
            dataGridViewFlightCrews.Columns["DateOfBirth"].DefaultCellStyle = new DataGridViewCellStyle
            { Format = "MM'/'dd'/'yyyy" };

            dataGridViewFlightCrews.AutoGenerateColumns = false;
            EditNoOfFlight();
        }

        private void AddColumns()
        {
            dataGridViewFlightCrews.Columns.Add("TotalFlights", "No. of Flights");
        }

        private void EditNoOfFlight()
        {
            dataGridViewFlightCrews.Columns["TotalFlights"].ValueType = typeof(int);
            foreach (DataGridViewRow row in dataGridViewFlightCrews.Rows)
            {
                var crew = (Crew)row.DataBoundItem;
                row.Cells["TotalFlights"].Value = flightCrewDAL.GetNoOfFlightFromCrew(crew.PersonId);
            }
        }

        private void buttonManageFlights_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageFlightsForm manageFlightForm = new ManageFlightsForm(user);
            manageFlightForm.ShowDialog();
            this.Close();
        }

        private void buttonManageCarrier_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManageFlightCarriersForm manageCarrierForm = new ManageFlightCarriersForm(user);
            manageCarrierForm.ShowDialog();
            this.Close();
        }

        private void buttonCreateFlightCrew_Click(object sender, EventArgs e)
        {
            CreateFlightCrewForm createCrewForm = new CreateFlightCrewForm(carrierList, user);
            createCrewForm.ShowDialog();
            comboBoxFilter.SelectedIndex = 0;
            RefreshDataGridCrews();
        }

        private void buttonViewUpdateFlightCrew_Click(object sender, EventArgs e)
        {
            if (dataGridViewFlightCrews.RowCount > 0)
            {
                Crew crew = (Crew)dataGridViewFlightCrews.CurrentRow.DataBoundItem;
                ViewUpdateFlightCrewDetailsForm viewCrewForm = new ViewUpdateFlightCrewDetailsForm(crew, carrierList, user);
                viewCrewForm.ShowDialog();
                RefreshDataGridCrews();
            }
            else
            {
                MessageBox.Show("Please select a flight crew to update", "Airline Reservation System Warning");
            }
        }

        private void buttonDeleteFlightCrew_Click(object sender, EventArgs e)
        {
            if (dataGridViewFlightCrews.RowCount > 0)
            {
                Crew crew = (Crew)dataGridViewFlightCrews.CurrentRow.DataBoundItem;
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this flight crew?",
                "Airline Reservation System Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        PersonDAL personDAL = new PersonDAL();
                        FlightCrewDAL flightCrewDAL = new FlightCrewDAL();
                        flightCrewDAL.DeleteFlightCrewFromPersonId(crew.PersonId);
                        personDAL.DeletePerson(crew);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") deleted flight crew: " + crew.PassportNo, w);
                        }

                        using (StreamReader r = File.OpenText("log.txt"))
                        {
                            LogAppend.DumpLog(r);
                        }
                        RefreshDataGridCrews();
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
                MessageBox.Show("Please select a flight crew to delete", "Airline Reservation System Warning");
            }
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFilter.SelectedIndex == 0)
            {
                crewList = crewDAL.getCrewList();
            }
            else
            {
                Carrier c = carrierDAL.SearchCarrierByName(comboBoxFilter.Text);
                crewList = crewDAL.getCrewListFromCarrier(c);
            }
            var bindingList = new BindingList<Crew>(crewList);
            var source = new BindingSource(bindingList, null);
            dataGridViewFlightCrews.DataSource = null;
            dataGridViewFlightCrews.DataSource = source;
            AdjustDatagrid();
        }

        private void DataGridVisibleChanged(object sender, EventArgs e)
        {
            EditNoOfFlight();
        }
    }
}
