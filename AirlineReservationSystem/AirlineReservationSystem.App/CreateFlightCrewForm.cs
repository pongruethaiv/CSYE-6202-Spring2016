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
    public partial class CreateFlightCrewForm : Form
    {
        private User user;
        List<Carrier> carrierList;
        private CarrierDAL carrierDAL;
        private CrewDAL crewDAL;
        private PersonDAL personDAL;

        public CreateFlightCrewForm(List<Carrier> carrierList, User user)
        {
            InitializeComponent();
            this.user = user;
            carrierDAL = new CarrierDAL();
            personDAL = new PersonDAL();
            crewDAL = new CrewDAL();
            this.carrierList = carrierList;
            Init();
        }

        private void Init()
        {
            LoadCarrierComboBox();
            if (comboBoxCarrier.Items.Count>0)
            {
                comboBoxCarrier.SelectedIndex = 0;
            }
            dateTimePickerDob.Value = DateTime.Now;
            dateTimePickerDob.MaxDate = DateTime.Now;
        }

        private void LoadCarrierComboBox()
        {
            comboBoxCarrier.Items.AddRange(carrierList.Cast<object>().ToArray());
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
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
                if(ValidationHelper.UserEnterAlphabetString(first) && ValidationHelper.UserEnterAlphabetString(last)
                    && ValidationHelper.UserEnterAlphabetString(nation) && ValidationHelper.UserEnterAlphanumeric(passport)
                    && dob <= DateTime.Now)
                {
                    var crewList = crewDAL.getCrewList();
                    foreach(Crew c in crewList)
                    {
                        if (c.PassportNo.ToLower().Equals(passport.ToLower()))
                        {
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                LogAppend.Log("(" + user.Role + ": " + user.Username + ") attemped to create new flight crew with duplicate data", w);
                            }

                            using (StreamReader r = File.OpenText("log.txt"))
                            {
                                LogAppend.DumpLog(r);
                            }
                            MessageBox.Show("Duplicate crew passport", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            goto endOfLoop;
                        }
                    }
                    string gender = string.Empty;
                    if (radioButtonFemale.Checked)
                    {
                        gender = "Female";
                    }
                    else gender = "Male";
                    try
                    {
                        Crew crew = new Crew(textBoxFirst.Text, textBoxLast.Text, textBoxPassport.Text, gender,
                        dob, textBoxNationality.Text, PersonType.Crew, carrierDAL.SearchCarrierByName(comboBoxCarrier.Text));
                        int id = personDAL.InsertPerson(crew);
                        crew.PersonId = id;
                        crewDAL.InsertCrew(crew);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") created new flight crew: " + crew.PassportNo, w);
                        }

                        using (StreamReader r = File.OpenText("log.txt"))
                        {
                            LogAppend.DumpLog(r);
                        }
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
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid inputs", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        endOfLoop:;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFirst.Text = "";
            textBoxLast.Text = "";
            textBoxNationality.Text = "";
            textBoxPassport.Text = "";
            if (comboBoxCarrier.Items.Count>0)
            {
                comboBoxCarrier.SelectedIndex = 0;
            }
            
            dateTimePickerDob.MaxDate = DateTime.Now;
            dateTimePickerDob.Value = DateTime.Now;
            radioButtonFemale.Checked = false;
            radioButtonMale.Checked = false;
        }
    }
}
