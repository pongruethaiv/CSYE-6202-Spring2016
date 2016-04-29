using AirlineReservationSystem.DAL;
using AirlineReservationSystem.Domain;
using AirlineReservationSystem.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirlineReservationSystem.App
{
    public partial class ViewUpdateFlightCrewDetailsForm : Form
    {
        private User user;
        private List<Carrier> carrierList;
        private List<Flight> roster;
        private FlightCrewDAL flightCrewDAL;
        private Crew crew;
        public List<Flight> newFlightList { get; set; }
        private CrewDAL crewDAL;
        private PersonDAL personDAL;
        private CarrierDAL carrierDAL;
        private string oldPassport;
        private Carrier oldCarrier;

        public ViewUpdateFlightCrewDetailsForm(Crew crew, List<Carrier> carrierList, User user)
        {
            InitializeComponent();
            this.user = user;
            this.crew = crew;
            this.carrierList = carrierList;
            Init();
        }

        private void Init()
        {
            oldCarrier = crew.FlightCarrier;
            flightCrewDAL = new FlightCrewDAL();
            crewDAL = new CrewDAL();
            personDAL = new PersonDAL();
            carrierDAL = new CarrierDAL();
            oldPassport = crew.PassportNo;
            LoadCarrierComboBox();
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
            dateTimePickerDob.MaxDate = DateTime.Now;
            LoadDataGridRoster();
            comboBoxCarrier.SelectedIndex = comboBoxCarrier.FindStringExact(crew.FlightCarrier.Name);
            LoadFilterByComboBox();
            comboBoxFilter.SelectedIndex = 0;
        }

        private void LoadCarrierComboBox()
        {
            comboBoxCarrier.Items.AddRange(carrierList.Cast<object>().ToArray());
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

        private void buttonAssignFlight_Click(object sender, EventArgs e)
        {
            AssignFlightToCrewForm assignFlightForm = new AssignFlightToCrewForm(roster,comboBoxCarrier.Text, this, user);
            assignFlightForm.ShowDialog();
            if (!Object.ReferenceEquals(newFlightList, null))
            {
                var bindingList = new BindingList<Flight>(newFlightList);
                var source = new BindingSource(bindingList, null);
                dataGridViewRoster.DataSource = null;
                dataGridViewRoster.DataSource = source;
                AdjustDatagrid();
            }
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonAssignFlight.Enabled = true;
            buttonClear.Enabled = true;
            buttonSave.Enabled = true;
            textBoxFirst.Enabled = true;
            textBoxLast.Enabled = true;
            textBoxNationality.Enabled = true;
            textBoxPassport.Enabled = true;
            radioButtonFemale.Enabled = true;
            radioButtonMale.Enabled = true;
            dateTimePickerDob.Enabled = true;
            comboBoxCarrier.Enabled = true;
            comboBoxFilter.Enabled = true;
            dataGridViewRoster.Enabled = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFirst.Text = "";
            textBoxLast.Text = "";
            textBoxNationality.Text = "";
            textBoxPassport.Text = "";
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
            dateTimePickerDob.MaxDate = DateTime.Now;
            dateTimePickerDob.Value = DateTime.Now;
            comboBoxCarrier.SelectedIndex = 0;
            comboBoxFilter.SelectedIndex = 0;
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

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string first = textBoxFirst.Text;
            string last = textBoxLast.Text;
            string nation = textBoxNationality.Text;
            string passport = textBoxPassport.Text;
            DateTime dob = dateTimePickerDob.Value;

            if (string.IsNullOrEmpty(first) || first.Trim().Equals("") ||
                string.IsNullOrEmpty(last) || last.Trim().Equals("") ||
                string.IsNullOrEmpty(nation) || nation.Trim().Equals("") ||
                string.IsNullOrEmpty(passport) || passport.Trim().Equals("") ||
                comboBoxCarrier.Items.Count == 0 ||
                (!radioButtonFemale.Checked && !radioButtonMale.Checked))
            {
                MessageBox.Show("Please fill in all the fields", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ValidationHelper.UserEnterAlphabetString(first) && ValidationHelper.UserEnterAlphabetString(last)
                    && ValidationHelper.UserEnterAlphabetString(nation) && ValidationHelper.UserEnterAlphanumeric(passport)
                     && dob <= DateTime.Now)
                {
                    var crewList = crewDAL.getCrewList();
                    foreach (Crew c in crewList)
                    {
                        if (c.PassportNo.ToLower().Equals(passport.ToLower()) && !crew.PersonId.Equals(c.PersonId))
                        {
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                LogAppend.Log("(" + user.Role + ": " + user.Username + ") attempted to update flight crew with duplicate data", w);
                            }

                            using (StreamReader r = File.OpenText("log.txt"))
                            {
                                LogAppend.DumpLog(r);
                            }
                            MessageBox.Show("Duplicate crew passport", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            goto endOfLoop;
                        }
                    }
                    DialogResult dr = MessageBox.Show("Are you sure you want to update this flight carrier?",
                "Airline Reservation System Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        Carrier oldCarrier = crew.FlightCarrier;
                        string gender;
                        if (radioButtonFemale.Checked)
                        {
                            gender = radioButtonFemale.Text;
                        }
                        else gender = radioButtonMale.Text;
                        string carrierName = comboBoxCarrier.Text;
                        crew.FirstName = first;
                        crew.LastName = last;
                        crew.Nationality = nation;
                        crew.PassportNo = passport;
                        crew.DateOfBirth = dob;
                        crew.Gender = gender;
                        crew.FlightCarrier = carrierDAL.SearchCarrierByName(carrierName);
                        personDAL.UpdatePerson(crew);

                        if (!crew.FlightCarrier.Name.Equals(oldCarrier.Name))
                        {
                            crewDAL.UpdateCrew(comboBoxCarrier.Text, crew.PersonId);
                        }

                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            if (oldPassport.ToLower().Equals(crew.PassportNo.ToLower()))
                            {
                                LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated flight crew: " + crew.PassportNo, w);
                            }
                            else LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated flight crew: " + oldPassport + " with new passport no.: " + crew.PassportNo, w);
                        }

                        using (StreamReader r = File.OpenText("log.txt"))
                        {
                            LogAppend.DumpLog(r);
                        }

                        flightCrewDAL.DeleteFlightCrewFromPersonId(crew.PersonId);

                        if (!Object.ReferenceEquals(GetFlightFromDataGrid(), null))
                        {
                            int i = 0;
                            foreach (Flight flight in GetFlightFromDataGrid())
                            {
                                flightCrewDAL.InsertNewAssignedFlightCrew(flight, crew.PersonId);
                                i++;
                            }
                            if (i > 0)
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    LogAppend.Log("(" + user.Role + ": " + user.Username + ") assigned flights to flight crew: " + crew.PassportNo, w);
                                }

                                using (StreamReader r = File.OpenText("log.txt"))
                                {
                                    LogAppend.DumpLog(r);
                                }
                            }
                        }

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid inputs", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        endOfLoop:;
        }

        private void comboBoxCarrier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (oldCarrier.Name.Equals(comboBoxCarrier.Text) && Object.ReferenceEquals(newFlightList, null))
            {
                var bindingList = new BindingList<Flight>(roster);
                var source = new BindingSource(bindingList, null);
                dataGridViewRoster.DataSource = null;
                dataGridViewRoster.DataSource = source;
                AdjustDatagrid();
            }
            else if (oldCarrier.Name.Equals(comboBoxCarrier.Text) && !Object.ReferenceEquals(newFlightList, null))
            {
                Flight flight = newFlightList.First();
                if (flight.FlightCarrier.Name.Equals(comboBoxCarrier.Text))
                {
                    var bindingList = new BindingList<Flight>(newFlightList);
                    var source = new BindingSource(bindingList, null);
                    dataGridViewRoster.DataSource = null;
                    dataGridViewRoster.DataSource = source;
                    AdjustDatagrid();
                }
                else
                {
                    var bindingList = new BindingList<Flight>(roster);
                    var source = new BindingSource(bindingList, null);
                    dataGridViewRoster.DataSource = null;
                    dataGridViewRoster.DataSource = source;
                    AdjustDatagrid();
                }
            }
            else if (!oldCarrier.Name.Equals(comboBoxCarrier.Text) && Object.ReferenceEquals(newFlightList, null))
            {
                Console.WriteLine("he");   
                dataGridViewRoster.DataSource = null;
            }
            else if (!oldCarrier.Name.Equals(comboBoxCarrier.Text) && !Object.ReferenceEquals(newFlightList, null))
            {
                Flight flight = newFlightList.First();
                if (flight.FlightCarrier.Name.Equals(comboBoxCarrier.Text))
                {
                    var bindingList = new BindingList<Flight>(newFlightList);
                    var source = new BindingSource(bindingList, null);
                    dataGridViewRoster.DataSource = null;
                    dataGridViewRoster.DataSource = source;
                    AdjustDatagrid();
                }
                else
                {
                    dataGridViewRoster.DataSource = null;
                }
            }
            
        }

        private List<Flight> GetFlightFromDataGrid()
        {
            List<Flight> flightList = new List<Flight>();
            foreach (DataGridViewRow row in dataGridViewRoster.Rows)
            {
                Flight flight = (Flight)row.DataBoundItem;
                flightList.Add(flight);
            }
            return flightList;
        }
    
    }
}
