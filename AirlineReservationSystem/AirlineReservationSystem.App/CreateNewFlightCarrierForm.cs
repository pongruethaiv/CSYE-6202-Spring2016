using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirlineReservationSystem.Domain;
using AirlineReservationSystem.DAL;
using System.Data.SqlClient;
using System.IO;
using AirlineReservationSystem.Logging;

namespace AirlineReservationSystem.App
{
    public partial class CreateNewFlightCarrierForm : Form
    {
        private User user;

        public CreateNewFlightCarrierForm(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            string name = textBoxName.Text;
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
                    Carrier c = new Carrier(name, country);
                    CarrierDAL carrierDAL = new CarrierDAL();
                    try
                    {
                        carrierDAL.InsertCarrier(c);
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            LogAppend.Log("(" + user.Role + ": " + user.Username + ") created new flight carrier: "+c.Name, w);
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
                                LogAppend.Log("(" + user.Role + ": " + user.Username + ") attemped to create new flight carrier with duplicate data", w);
                                MessageBox.Show("Duplicate flight carrier name", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                else
                {
                    MessageBox.Show("Invalid inputs", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxCountry.Text = "";
        }
    }
}
