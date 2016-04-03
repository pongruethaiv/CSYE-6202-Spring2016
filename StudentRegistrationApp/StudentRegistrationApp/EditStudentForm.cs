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
    public partial class EditStudentForm : Form
    {
        private List<Student> studentList;
        private Student student;
        private string[] departmentItems;

        public EditStudentForm(Student student, List<Student> studentList, string[] departmentItems)
        {
            this.student = student;
            this.studentList = studentList;
            this.departmentItems = departmentItems;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadDepartments();
            LoadStudentDetail();
        }

        private void LoadStudentDetail()
        {
            textBoxID.Text = student.StudentID;
            textBoxFirst.Text = student.FirstName;
            textBoxLast.Text = student.LastName;
            string department = student.Department;
            for (int i=0; i< departmentItems.Count(); i++)
            {
                if (departmentItems[i].Equals(department))
                {
                    comboBoxDepartment.SelectedIndex = i;
                    break;
                }
            }
            
            if (radioButtonFullTime.Text.Equals(student.EnrollmentType))
            {
                radioButtonFullTime.Checked = true;
            }
            else radioButtonPartTime.Checked = true;
        }

        private void LoadDepartments()
        {
            comboBoxDepartment.Items.AddRange(departmentItems);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            string studentID = textBoxID.Text;
            string firstName = textBoxFirst.Text;
            string lastName = textBoxLast.Text;
            if (string.IsNullOrEmpty(studentID) || studentID.Trim().Equals("") || string.IsNullOrEmpty(firstName) || firstName.Trim().Equals("")
                || string.IsNullOrEmpty(lastName) || lastName.Trim().Equals(""))
            {
                MessageBox.Show("Please fill in all the fields", "Edit Student Registration Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    DialogResult dr = MessageBox.Show("Are you sure you want to update this student?",
                "Edit Student Registration Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        student.FirstName = firstName;
                        student.LastName = lastName;
                        student.StudentID = studentID;
                        student.Department = comboBoxDepartment.Text;
                        student.EnrollmentType = enrollType;

                        this.Close();
                    }
                    else if (dr == DialogResult.No)
                    {
                        this.Close();
                    }

                }
                else MessageBox.Show("Please check your input.", "Edit Student Registration Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool ValidateStudentDetail(string studentID, string firstName, string lastName)
        {
            if (Regex.IsMatch(studentID, @"^\d{3}-\d{2}-\d{4}$") && Regex.IsMatch(firstName, @"^[A-Za-z]+$") && Regex.IsMatch(lastName, @"^[A-Za-z]+$"))
            {
                foreach (Student s in studentList)
                {
                    if (s.StudentID.Equals(studentID) && !s.Equals(student))
                    {
                        return false;
                    }
                }
                return true;
            }
            else return false;
        }
    }
}
