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
    public partial class ViewRosterRequestForm : Form
    {
        private User user;
        private CrewDAL crewDAL;

        public ViewRosterRequestForm(User user)
        {
            InitializeComponent();
            this.user = user;
            Init();
        }

        private void Init()
        {
            crewDAL = new CrewDAL();
        }

        private void buttonViewDetails_Click(object sender, EventArgs e)
        {
            string passport = textBoxPassportNo.Text;
            if (string.IsNullOrEmpty(passport) || passport.Trim().Equals(""))
            {
                MessageBox.Show("Please fill in all the fields", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (ValidationHelper.UserEnterAlphanumeric(passport))
                {
                    Crew crew = crewDAL.SearchCrewFromPassportNo(passport);
                    if (!object.ReferenceEquals(crew, null))
                    {
                        ViewRosterForm viewRosterForm = new ViewRosterForm(crew, user);
                        viewRosterForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No record found", "Airline Reservation System Warning");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid input", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        }
    }
}
