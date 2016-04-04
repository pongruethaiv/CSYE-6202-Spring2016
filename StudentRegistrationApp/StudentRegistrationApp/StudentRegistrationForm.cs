using StudentRegistration.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationApp
{
    public partial class StudentRegistrationForm : Form
    {
        private List<Student> mockStudentList;
        private string[] departmentItems;

        public delegate void PassStudentList(List<Student> studentList);

        #region Constructors

        public StudentRegistrationForm()
        {
            mockStudentList = new List<Student>();
            InitializeComponent();
            Init();
        }

        #endregion

        #region Methods

        // good software programming practice!!
        private void Init()
        {
            LoadDepartments();
            LoadDataGridWithMockData();
            LoadDefaults();
        }

        private void LoadDepartments()
        {
            departmentItems = new[] { "Information Systems", "International Affairs", "Nursing", "Pharmacy",
                "Professional Studies", "Psychology", "Public Administration" };
            comboBoxDepartment.Items.AddRange(departmentItems);
        }

        // since we don't know ADO.NET and/or File I/O we will get static mock data
        private void LoadDataGridWithMockData()
        {
            string[] idArray = new string[10];
            for (int i = 0; i < 10; i++)
            {
                string randomID = StudentHelper.RandomID();
                int pos = Array.IndexOf(idArray, randomID);
                while (pos > -1)
                {
                    randomID = StudentHelper.RandomID();
                    pos = Array.IndexOf(idArray, randomID);
                }
                idArray[i] = randomID;
            }

            for (int i = 0; i < 10; i++)
            {
                mockStudentList.Add(new Student(idArray[i], StudentHelper.RandomFirstName(), StudentHelper.RandomLastName(), StudentHelper.RandomDepartment(), StudentHelper.RandomEnrollmentType()));
            }

            // dirty workaround to make sure that we can bind to the static mock list
            var bindingList = new BindingList<Student>(mockStudentList);
            var source = new BindingSource(bindingList, null);
            dataGridViewStudents.DataSource = source;
            AdjustColumnOrder();
        }

        private void AdjustColumnOrder()
        {
            dataGridViewStudents.Columns["StudentID"].DisplayIndex = 0;
            dataGridViewStudents.Columns["FirstName"].DisplayIndex = 1;
            dataGridViewStudents.Columns["LastName"].DisplayIndex = 2;
            dataGridViewStudents.Columns["Department"].DisplayIndex = 3;
            dataGridViewStudents.Columns["EnrollmentType"].DisplayIndex = 4;
        }

        public void PerformRefresh()
        {
            var bindingList = new BindingList<Student>(mockStudentList);
            var source = new BindingSource(bindingList, null);
            dataGridViewStudents.DataSource = null;
            dataGridViewStudents.DataSource = source;
            AdjustColumnOrder();
        }

        private void LoadDefaults()
        {
            radioButtonFullTime.Select();
            comboBoxDepartment.SelectedIndex = 0;
        }

        #endregion

        private void HandleDataGridViewStudentsSelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
            {
                textBoxID.Text = row.Cells[0].Value.ToString();
                textBoxFirst.Text = row.Cells[3].Value.ToString();
                textBoxLast.Text = row.Cells[4].Value.ToString();

                comboBoxDepartment.SelectedIndex = comboBoxDepartment.Items.IndexOf(row.Cells[1].Value.ToString());

                // enrollment type selection driven by the grid itself
                var enrollmentType = row.Cells[2].Value.ToString();
                if (radioButtonFullTime.Text == enrollmentType)
                {
                    radioButtonFullTime.Checked = true;
                }
                else if (radioButtonPartTime.Text == enrollmentType)
                {
                    radioButtonPartTime.Checked = true;
                }
            }
        }

        private void buttonNewStudent_Click(object sender, EventArgs e)
        {
            NewStudentForm newStudentForm = new NewStudentForm(departmentItems);
            PassStudentList p = new PassStudentList(newStudentForm.ReceiveStudentList);
            p(mockStudentList);
            newStudentForm.ShowDialog();
            PerformRefresh();
        }

        private void buttonRemoveStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Student currentStudent = (Student)dataGridViewStudents.CurrentRow.DataBoundItem;
                RemoveStudentForm removeForm = new RemoveStudentForm(currentStudent, mockStudentList);
                removeForm.ShowDialog();
                PerformRefresh();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a student to remove", "Student Registration Warning");
            }
        }

        private void buttonEditStudent_Click(object sender, EventArgs e)
        {
            try
            {
                Student currentStudent = (Student)dataGridViewStudents.CurrentRow.DataBoundItem;
                EditStudentForm editForm = new EditStudentForm(currentStudent, mockStudentList, departmentItems);
                editForm.ShowDialog();
                PerformRefresh();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a student to edit", "Student Registration Warning");
            }
        }
    }
}
