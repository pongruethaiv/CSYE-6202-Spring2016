using StudentRegistration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Interaction logic for RemoveStudentRegistration.xaml
    /// </summary>
    public partial class RemoveStudentRegistration : Window
    {
        private Student student;
        private List<Student> studentList;

        public RemoveStudentRegistration(Student student, List<Student> studentList)
        {
            this.student = student;
            this.studentList = studentList;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadStudentDetail();
        }

        private void LoadStudentDetail()
        {
            textBoxID.Text = student.StudentID;
            textBoxFirstName.Text = student.FirstName;
            textBoxLastName.Text = student.LastName;
            comboBoxDepartment.Items.Add(student.Department);
            comboBoxDepartment.SelectedIndex = 0;
            if (radioButtonFullTime.Content.Equals(student.EnrollmentType))
            {
                radioButtonFullTime.IsChecked = true;
            }
            else radioButtonPartTime.IsChecked = true;
        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this student?",
                "Remove Student Registration Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                studentList.Remove(student);
                this.Close();
            }
            else if (result == MessageBoxResult.No)
            {
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
