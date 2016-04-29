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
    public partial class FindBookingForm : Form
    {
        private User user;
        private TicketDAL ticketDAL;

        public FindBookingForm(User user)
        {
            InitializeComponent();
            ticketDAL = new TicketDAL();
            this.user = user;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string tickNo = textBoxBookingNo.Text;
            if (string.IsNullOrEmpty(tickNo) || tickNo.Trim().Equals(""))
            {
                MessageBox.Show("Please enter booking confirmation number", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(ValidationHelper.UserEnterInteger(tickNo))
                {
                    Ticket ticket = ticketDAL.SearchTicketByTicketId(Convert.ToInt32(textBoxBookingNo.Text));
                    if (object.ReferenceEquals(ticket, null))
                    {
                        MessageBox.Show("No booking found", "Airline Reservation System Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        BookTicketConfirmationForm ticketConfirmForm = new BookTicketConfirmationForm(ticket, user);
                        ticketConfirmForm.ShowDialog();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid booking confirmation number", "Airline Reservation System Warning");
                }

            }
            
        }
    }
}
