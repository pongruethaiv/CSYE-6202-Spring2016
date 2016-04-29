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
    public partial class UpdateFlightCarrierForm : Form
    {
        private User user;
        private Carrier carrier;
        private string oldName;

        public UpdateFlightCarrierForm(Carrier c, User user)
        {
            InitializeComponent();
            this.carrier = c;
            this.user = user;
            textBoxAirline.Text = carrier.Name;
            textBoxCountry.Text = carrier.Country;
            oldName = carrier.Name;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxAirline.Text = "";
            textBoxCountry.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string name = textBoxAirline.Text;
            string country = textBoxCountry.Text;

            if (string.IsNullOrEmpty(name) || name.Trim().Equals("") ||
                string.IsNullOrEmpty(country) || country.Trim().Equals(""))
            {
                MessageBox.Show("Please fill in all the fields", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ValidationHelper.UserEnterAlphabetStringWithSpace(name) && ValidationHelper.UserEnterAlphabetStringWithSpace(country))
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to update this flight carrier?",
                "Airline Reservation System Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        carrier.Name = name;
                        carrier.Country = country;
                        CarrierDAL carrierDAL = new CarrierDAL();
                        try
                        {
                            carrierDAL.UpdateCarrier(carrier, oldName);
                            using (StreamWriter w = File.AppendText("log.txt"))
                            {
                                if (carrier.Name.ToLower().Equals(oldName.ToLower()))
                                {
                                    LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated new flight carrier: " + carrier.Name, w);
                                }
                                else LogAppend.Log("(" + user.Role + ": " + user.Username + ") updated new flight carrier: " + oldName+" with name: "+carrier.Name, w);
                            }

                            using (StreamReader r = File.OpenText("log.txt"))
                            {
                                LogAppend.DumpLog(r);
                            }
                            this.Close();
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Number == 2627)
                            {
                                using (StreamWriter w = File.AppendText("log.txt"))
                                {
                                    LogAppend.Log("(" + user.Role + ": " + user.Username + ") attemped to update flight carrier with duplicate data", w);
                                }

                                using (StreamReader r = File.OpenText("log.txt"))
                                {
                                    LogAppend.DumpLog(r);
                                }
                                MessageBox.Show("Duplicate flight carrier name", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else MessageBox.Show("Execute exception issue: " + ex.Message);
                        }
                        
                    }
                    
                }
                else
                {
                    MessageBox.Show("Invalid inputs", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
