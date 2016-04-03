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
    /// Interaction logic for EditStudentRegistration.xaml
    /// </summary>
    public partial class EditStudentRegistration : Window
    {
        private List<Student> studentList;
        private Student student;
        private string[] departmentItems;

        public EditStudentRegistration(Student student, List<Student> studentList, string[] departmentItems)
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

        private void LoadDepartments()
        {
            foreach (string s in departmentItems)
            {
                comboBoxDepartment.Items.Add(s);
            }
        }

        private void LoadStudentDetail()
        {
            textBoxID.Text = student.StudentID;
            textBoxFirstName.Text = student.FirstName;
            textBoxLastName.Text = student.LastName;
            string department = student.Department;
            for (int i = 0; i < departmentItems.Count(); i++)
            {
                if (departmentItems[i].Equals(department))
                {
                    comboBoxDepartment.SelectedIndex = i;
                    break;
                }
            }

            if (radioButtonFullTime.Content.Equals(student.EnrollmentType))
            {
                radioButtonFullTime.IsChecked = true;
            }
            else radioButtonPartTime.IsChecked = true;
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            string studentID = textBoxID.Text;
            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            if (string.IsNullOrEmpty(studentID) || studentID.Trim().Equals("") || string.IsNullOrEmpty(firstName) || firstName.Trim().Equals("")
                || string.IsNullOrEmpty(lastName) || lastName.Trim().Equals(""))
            {
                MessageBox.Show("Please fill in all the fields", "Edit Student Registration Warning");
            }
            else
            {
                string enrollType;
                if ((bool)radioButtonFullTime.IsChecked)
                {
                    enrollType = "Full Time";
                }
                else enrollType = "Part Time";

                if (ValidateStudentDetail(studentID, firstName, lastName))
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to update this student?",
                "Edit Student Registration Confirmation", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        student.FirstName = firstName;
                        student.LastName = lastName;
                        student.StudentID = studentID;
                        student.Department = comboBoxDepartment.Text;
                        student.EnrollmentType = enrollType;

                        this.Close();
                    }
                    else if (result == MessageBoxResult.No)
                    {
                        this.Close();
                    }

                }
                else MessageBox.Show("Please check your input.", "Edit Student Registration Warning");
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

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
