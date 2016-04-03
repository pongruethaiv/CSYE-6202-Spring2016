using StudentRegistration.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for StudentRegistrationMain.xaml
    /// </summary>
    public partial class StudentRegistrationMain : Window
    {
        private List<Student> mockStudentList;
        private string[] departmentItems;

        public StudentRegistrationMain()
        {
            mockStudentList = new List<Student>();
            InitializeComponent();
            Init();
        }

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
            foreach (string s in departmentItems)
            {
                comboBoxDepartment.Items.Add(s);
            }
        }

        private void LoadDefaults()
        {
            radioButtonFullTime.IsChecked = false;
            radioButtonPartTime.IsChecked = false;
            comboBoxDepartment.SelectedIndex = -1;
            textBoxID.Text = "";
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
        }

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
            
            PerformRefresh();
        }

        public void PerformRefresh()
        {
            dataGridViewStudents.ItemsSource = null;
            dataGridViewStudents.ItemsSource = mockStudentList;
        }

        private void AdjustColumnOrder(object sender, EventArgs e)
        {
            if (dataGridViewStudents.Columns.Count == 5)
            {
                dataGridViewStudents.Columns[0].DisplayIndex = 0;
                dataGridViewStudents.Columns[1].DisplayIndex = 3;
                dataGridViewStudents.Columns[2].DisplayIndex = 4;
                dataGridViewStudents.Columns[3].DisplayIndex = 1;
                dataGridViewStudents.Columns[4].DisplayIndex = 2;
            }
        }

        private void HandleDataGridViewStudentsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var student = dataGridViewStudents.SelectedItem as Student;
            if (student != null)
            {
                textBoxID.Text = student.StudentID;
                textBoxFirstName.Text = student.FirstName;
                textBoxLastName.Text = student.LastName;
                comboBoxDepartment.SelectedIndex = comboBoxDepartment.Items.IndexOf(student.Department);
                if (radioButtonFullTime.Content.Equals(student.EnrollmentType))
                {
                    radioButtonFullTime.IsChecked = true;
                }
                else radioButtonPartTime.IsChecked = true;
            }
            //DataGrid dataGridViewStudents = sender as DataGrid;
            //DataGridRow row = (DataGridRow)dataGridViewStudents.ItemContainerGenerator.ContainerFromIndex(dataGridViewStudents.SelectedIndex);
            //DataGridCell[] rowColumn = new DataGridCell[dataGridViewStudents.Columns.Count()];

            //for (int i = 0; i < dataGridViewStudents.Columns.Count(); i++)
            //{
            //    rowColumn[i] = dataGridViewStudents.Columns[i].GetCellContent(row).Parent as DataGridCell;
            //}
            //textBoxID.Text = ((TextBlock)rowColumn[0].Content).Text;
            //textBoxFirstName.Text = ((TextBlock)rowColumn[3].Content).Text;
            //textBoxLastName.Text = ((TextBlock)rowColumn[4].Content).Text;
            //comboBoxDepartment.SelectedIndex = comboBoxDepartment.Items.IndexOf(((TextBlock)rowColumn[1].Content).Text);
            //string enrollmentType = ((TextBlock)rowColumn[2].Content).Text;
            //if (radioButtonFullTime.Content.Equals(enrollmentType))
            //{
            //    radioButtonFullTime.IsChecked = true;
            //}
            //else if (radioButtonPartTime.Content.Equals(enrollmentType))
            //{
            //    radioButtonPartTime.IsChecked = true;
            //}
        }

        private void buttonNewStudent_Click(object sender, RoutedEventArgs e)
        {
            NewStudentRegistration newStudentForm = new NewStudentRegistration(mockStudentList, departmentItems);
            newStudentForm.ShowDialog();
            PerformRefresh();
            LoadDefaults();
        }

        private void buttonRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            Student currentStudent = dataGridViewStudents.SelectedItem as Student;
            if (currentStudent!=null)
            {
                RemoveStudentRegistration removeStudentForm = new RemoveStudentRegistration(currentStudent, mockStudentList);
                removeStudentForm.ShowDialog();
                PerformRefresh();
                LoadDefaults();
            }
            else
            {
                MessageBox.Show("Please select a student to remove", "Student Registration Warning");
            }
        }

        private void buttonEditStudent_Click(object sender, RoutedEventArgs e)
        {
            Student currentStudent = dataGridViewStudents.SelectedItem as Student;
            if (currentStudent != null)
            {
                EditStudentRegistration editStudentForm = new EditStudentRegistration(currentStudent, mockStudentList, departmentItems);
                editStudentForm.ShowDialog();
                PerformRefresh();
                LoadDefaults();
            }
            else
            {
                MessageBox.Show("Please select a student to edit", "Student Registration Warning");
            }
        }
    }
}
