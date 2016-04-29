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
    public partial class AddCrewToFlightForm : Form
    {
        private User user;
        private string carrierName;
        private CarrierDAL carrierDAL;
        private CrewDAL crewDAL;
        private List<Crew> crewList;
        private ViewUpdateFlightDetailsForm parentForm;

        public AddCrewToFlightForm(string carrierName, ViewUpdateFlightDetailsForm form, User user)
        {
            this.user = user;
            InitializeComponent();
            this.carrierName = carrierName;
            parentForm = form;
            Init();
        }

        private void Init()
        {
            carrierDAL = new CarrierDAL();
            crewDAL = new CrewDAL();
            LoadDatagridCrew();
        }

        private void LoadDatagridCrew()
        {
            crewList = crewDAL.getCrewListFromCarrier(carrierDAL.SearchCarrierByName(carrierName));
            var bindingList = new BindingList<Crew>(crewList);
            var source = new BindingSource(bindingList, null);
            dataGridViewCrews.DataSource = null;
            dataGridViewCrews.DataSource = source;
            AddCheckBoxColumnToDataGrid();
            AdjustColumnOrder();
        }

        private void AdjustColumnOrder()
        {
            dataGridViewCrews.Columns["FlightCarrier"].Visible = false;
            dataGridViewCrews.Columns["PersonId"].Visible = false;
            dataGridViewCrews.Columns["DateOfBirth"].Visible = false;
            dataGridViewCrews.Columns["PersonType"].Visible = false;
            dataGridViewCrews.Columns["PassportNo"].DisplayIndex = 1;
            dataGridViewCrews.Columns["PassportNo"].HeaderText = "Passport Number";
            dataGridViewCrews.Columns["FirstName"].HeaderText = "First Name";
            dataGridViewCrews.Columns["LastName"].HeaderText = "Last Name";
        }

        private void AddCheckBoxColumnToDataGrid()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridViewCrews.Columns.Insert(0, checkBoxColumn);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            List<Crew> crewList = GetCrewFromDataGridCrew();
            parentForm.CrewListUpdate = crewList;
            this.Close();
        }

        private List<Crew> GetCrewFromDataGridCrew()
        {
            List<Crew> crewList = new List<Crew>();
            foreach (DataGridViewRow row in dataGridViewCrews.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    Crew crew = (Crew)row.DataBoundItem;
                    crewList.Add(crew);
                    //crewPassport.Add(row.Cells["PassportNo"].Value.ToString());
                }
            }
            return crewList;
        }
    }
}
