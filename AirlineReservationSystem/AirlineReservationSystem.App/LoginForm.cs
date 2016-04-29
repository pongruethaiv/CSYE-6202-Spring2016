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
using G = System.Configuration;

namespace AirlineReservationSystem.App
{
    public partial class LoginForm : Form
    {
        int attempt;
        UserDAL userDAL;

        public LoginForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            userDAL = new UserDAL();
            attempt = 0;
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUsername.Text) || textBoxUsername.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter username", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter password", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                User user = userDAL.AuthenticateUsernameAndPassword(textBoxUsername.Text, textBoxPassword.Text);
                if (user!=null && user.Role.Equals(RoleType.Administrator))
                {
                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") logged in", w);
                    }

                    using (StreamReader r = File.OpenText("log.txt"))
                    {
                        LogAppend.DumpLog(r);
                    }
                    this.Hide();
                    AdminMainForm adminForm = new AdminMainForm(user);
                    adminForm.ShowDialog();
                    this.Close();
                }
                else if (user!= null && user.Role.Equals(RoleType.Regular))
                {
                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") logged in", w);
                    }

                    using (StreamReader r = File.OpenText("log.txt"))
                    {
                        LogAppend.DumpLog(r);
                    }
                    this.Hide();
                    PassengerMainForm passengerForm = new PassengerMainForm(user);
                    passengerForm.ShowDialog();
                    this.Close();
                }
                else if (user != null && user.Role.Equals(RoleType.Crew))
                {
                    using (StreamWriter w = File.AppendText("log.txt"))
                    {
                        LogAppend.Log("(" + user.Role + ": " + user.Username + ") logged in", w);
                    }

                    using (StreamReader r = File.OpenText("log.txt"))
                    {
                        LogAppend.DumpLog(r);
                    }
                    this.Hide();
                    CrewMainForm crewMainForm = new CrewMainForm(user);
                    crewMainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    attempt++;
                    MessageBox.Show("Username and password does not exist.", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (attempt == 3)
                    {
                        using (StreamWriter w = File.AppendText("log.txt"))
                        {
                            LogAppend.Log("Reached maximum three log in attempts", w);
                        }

                        using (StreamReader r = File.OpenText("log.txt"))
                        {
                            LogAppend.DumpLog(r);
                        }
                        MessageBox.Show("You have reached maximum three unsuccessful attempts.", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Environment.Exit(0);
                    }
                }
            }
            
        }
        
    }
}
