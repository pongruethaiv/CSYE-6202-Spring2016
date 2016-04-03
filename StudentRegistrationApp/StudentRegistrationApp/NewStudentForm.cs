using StudentRegistration.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationApp
{
    public partial class NewStudentForm : Form
    {
        private List<Student> studentList;
        private bool isDirty = false;
        private string[] departmentItems;

        public NewStudentForm(string[] departmentItems)
        {
            this.departmentItems = departmentItems;
            InitializeComponent();
            LoadDepartments();
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            radioButtonFullTime.Select();
            comboBoxDepartment.SelectedIndex = 0;
        }

        private void LoadDepartments()
        {
            comboBoxDepartment.Items.AddRange(departmentItems);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string studentID = textBoxID.Text;
            string firstName = textBoxFirst.Text;
            string lastName = textBoxLast.Text;
            if (string.IsNullOrEmpty(studentID) || studentID.Trim().Equals("") || string.IsNullOrEmpty(firstName) || firstName.Trim().Equals("")
                || string.IsNullOrEmpty(lastName) || lastName.Trim().Equals(""))
            {
                MessageBox.Show("Please fill in all the fields", "New Student Registration Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string enrollType;
                if (radioButtonFullTime.Checked)
                {
                    enrollType = "Full Time";
                }
                else enrollType = "Part Time";

                if (ValidateStudentDetail(studentID, firstName, lastName))
                {
                    Student s = new Student(studentID, firstName, lastName, comboBoxDepartment.Text, enrollType);
                    studentList.Add(s);
                    //int size = studentList.Count;
                    //MessageBox.Show(size.ToString(), "ing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else MessageBox.Show("Please check your input.", "New Student Registration Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void ReceiveStudentList(List<Student> studentList)
        {
            this.studentList = studentList;
        }

        public bool ValidateStudentDetail(string studentID, string firstName, string lastName)
        {
            if (Regex.IsMatch(studentID, @"^\d{3}-\d{2}-\d{4}$") && Regex.IsMatch(firstName, @"^[A-Za-z]+$") && Regex.IsMatch(lastName, @"^[A-Za-z]+$"))
            {
                foreach (Student s in studentList)
                {
                    if (s.StudentID.Equals(studentID))
                    {
                        return false;
                    }
                }
                return true;
            }
            else return false;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            LoadDefaults();
            textBoxID.Text = "";
            textBoxFirst.Text = "";
            textBoxLast.Text = "";
            textBoxID.Focus();
            textBoxID.SelectionStart = textBoxID.Text.Length;
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
            enableButtons();
        }

        private void textBoxFirst_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
            enableButtons();
        }

        private void textBoxLast_TextChanged(object sender, EventArgs e)
        {
            isDirty = true;
            enableButtons();
        }

        private void enableButtons()
        {
            if (isDirty)
            {
                buttonAdd.Enabled = true;
                buttonReset.Enabled = true;
            }
        }

    }
}
