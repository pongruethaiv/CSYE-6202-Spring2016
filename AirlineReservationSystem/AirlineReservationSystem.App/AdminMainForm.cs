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
    public partial class AdminMainForm : Form
    {
        private User user;

        public AdminMainForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void buttonAdminRole_Click(object sender, EventArgs e)
        {
            ManageFlightsForm manageFlightForm = new ManageFlightsForm(user);
            manageFlightForm.ShowDialog();
        }

        private void buttonPassenger_Click(object sender, EventArgs e)
        {
            SearchFlightForm passengerForm = new SearchFlightForm(user);
            passengerForm.ShowDialog();
        }

        private void buttonFindTicket_Click(object sender, EventArgs e)
        {
            FindBookingForm findBookingForm = new FindBookingForm(user);
            findBookingForm.ShowDialog();
        }

        private void buttonCrewRole_Click(object sender, EventArgs e)
        {
            ViewRosterRequestForm viewRosterReq = new ViewRosterRequestForm(user);
            viewRosterReq.ShowDialog();
        }
    }
}
