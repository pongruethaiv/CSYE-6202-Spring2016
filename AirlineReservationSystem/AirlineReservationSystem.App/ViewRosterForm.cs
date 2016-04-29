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
    public partial class ViewRosterForm : Form
    {
        private User user;
        private Crew crew;
        private List<Flight> roster;
        private FlightCrewDAL flightCrewDAL;

        public ViewRosterForm(Crew crew, User user)
        {
            InitializeComponent();
            this.crew = crew;
            this.user = user;
            Init();
        }

        private void Init()
        {
            flightCrewDAL = new FlightCrewDAL();
            textBoxFlightCarrier.Text = crew.FlightCarrier.Name;
            textBoxFirst.Text = crew.FirstName;
            textBoxLast.Text = crew.LastName;
            textBoxNationality.Text = crew.Nationality;
            textBoxPassport.Text = crew.PassportNo;
            if (crew.Gender.Equals("Female"))
            {
                radioButtonFemale.Checked = true;
            }
            else radioButtonMale.Checked = true;
            dateTimePickerDob.Value = crew.DateOfBirth;
            LoadDataGridRoster();
            LoadFilterByComboBox();
            comboBoxFilter.SelectedIndex = 0;
        }

        private void LoadFilterByComboBox()
        {
            string[] filterBy = new[] { "All Flights", "Future Flights", "Past Flights" };
            comboBoxFilter.Items.AddRange(filterBy);
        }

        private void LoadDataGridRoster()
        {
            roster = flightCrewDAL.GetRosterFromCrew(crew);
            var bindingList = new BindingList<Flight>(roster);
            var source = new BindingSource(bindingList, null);
            dataGridViewRoster.DataSource = null;
            dataGridViewRoster.DataSource = source;
            AdjustDatagrid();
        }

        private void AdjustDatagrid()
        {
            dataGridViewRoster.Columns["FlightCarrier"].DisplayIndex = 0;
            dataGridViewRoster.Columns["FlightNumber"].DisplayIndex = 1;
            dataGridViewRoster.Columns["Origin"].DisplayIndex = 2;
            dataGridViewRoster.Columns["Destination"].DisplayIndex = 3;
            dataGridViewRoster.Columns["DepartureTime"].DisplayIndex = 4;
            dataGridViewRoster.Columns["ArrivalTime"].DisplayIndex = 5;

            dataGridViewRoster.Columns["Price"].Visible = false;
            dataGridViewRoster.Columns["AvailableSeat"].Visible = false;

            dataGridViewRoster.Columns["FlightCarrier"].HeaderText = "Carrier";
            dataGridViewRoster.Columns["FlightNumber"].HeaderText = "Flight Number";
            dataGridViewRoster.Columns["ArrivalTime"].HeaderText = "Arrival Time";
            dataGridViewRoster.Columns["DepartureTime"].HeaderText = "Departure Time";

            //dataGridViewRoster.Columns["DateOfBirth"].DefaultCellStyle = new DataGridViewCellStyle
            //{ Format = "MM'/'dd'/'yyyy" };
        }

        private void buttonDismiss_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            roster = flightCrewDAL.GetRosterFromCrew(crew);
            DateTime now = DateTime.Now;
            if (comboBoxFilter.SelectedIndex == 0)
            {
                var bindingList = new BindingList<Flight>(roster);
                var source = new BindingSource(bindingList, null);
                dataGridViewRoster.DataSource = null;
                dataGridViewRoster.DataSource = source;
            }
            else if (comboBoxFilter.SelectedIndex == 1)
            {
                var futureList = new List<Flight>();
                foreach (Flight f in roster)
                {
                    int result = DateTime.Compare(now, f.ArrivalTime);
                    if (result <= 0)
                    {
                        futureList.Add(f);
                    }
                }
                var bindingList = new BindingList<Flight>(futureList);
                var source = new BindingSource(bindingList, null);
                dataGridViewRoster.DataSource = null;
                dataGridViewRoster.DataSource = source;
            }
            else if (comboBoxFilter.SelectedIndex == 2)
            {
                List<Flight> pastList = new List<Flight>();
                foreach (Flight f in roster)
                {
                    int result = DateTime.Compare(DateTime.Now, f.ArrivalTime);
                    if (result > 0)
                    {
                        pastList.Add(f);
                    }
                }
                var bindingList = new BindingList<Flight>(pastList);
                var source = new BindingSource(bindingList, null);
                dataGridViewRoster.DataSource = null;
                dataGridViewRoster.DataSource = source;
            }
            AdjustDatagrid();
        }
    }
}
