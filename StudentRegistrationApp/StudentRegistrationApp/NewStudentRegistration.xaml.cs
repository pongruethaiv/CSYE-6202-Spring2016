using StudentRegistration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentRegistrationApp
{
    /// <summary>
    /// Interaction logic for NewStudentRegistration.xaml
    /// </summary>
    public partial class NewStudentRegistration : Window
    {
        private List<Student> studentList;
        private bool isDirty = false;
        private string[] departmentItems;

        public NewStudentRegistration(List<Student> studentList, string[] departmentItems)
        {
            this.studentList = studentList;
            this.departmentItems = departmentItems;
            InitializeComponent();
            LoadDepartments();
            LoadDefaults();
        }

        private void LoadDefaults()
        {
            radioButtonFullTime.IsChecked = true;
            comboBoxDepartment.SelectedIndex = 0;
        }

        private void LoadDepartments()
        {
            foreach (string s in departmentItems)
            {
                comboBoxDepartment.Items.Add(s);
            }
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

        private void textBoxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDirty = true;
            enableButtons();
        }

        private void textBoxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDirty = true;
            enableButtons();
        }

        private void textBoxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDirty = true;
            enableButtons();
        }
        
        private void enableButtons()
        {
            if (isDirty)
            {
                buttonAdd.IsEnabled = true;
                buttonReset.IsEnabled = true;
            }
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            LoadDefaults();
            textBoxID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxID.Focus();
            textBoxID.SelectionStart = textBoxID.Text.Length;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            string studentID = textBoxID.Text;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            if (string.IsNullOrEmpty(studentID) || studentID.Trim().Equals("") || string.IsNullOrEmpty(firstName) || firstName.Trim().Equals("")
                || string.IsNullOrEmpty(lastName) || lastName.Trim().Equals(""))
            {
                MessageBox.Show("Please fill in all the fields", "New Student Registration Warning");
            }
            else
            {
                string enrollType;
                if ((bool) radioButtonFullTime.IsChecked)
                {
                    enrollType = "Full Time";
                }
                else enrollType = "Part Time";

                if (ValidateStudentDetail(studentID, firstName, lastName))
                {
                    Student s = new Student(studentID, firstName, lastName, comboBoxDepartment.Text, enrollType);
                    studentList.Add(s);
                    this.Close();
                }
                else MessageBox.Show("Please check your input.", "New Student Registration Warning");
            }
        }
    }
}
