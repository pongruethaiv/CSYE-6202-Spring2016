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
    public partial class RemoveStudentForm : Form
    {
        private List<Student> studentList;
        private Student student;

        public RemoveStudentForm(Student student, List<Student> studentList)
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
            textBoxFirst.Text = student.FirstName;
            textBoxLast.Text = student.LastName;
            comboBoxDepartment.Text = student.Department;
            if (radioButtonFullTime.Text.Equals(student.EnrollmentType))
            {
                radioButtonFullTime.Checked = true;
            }
            else radioButtonPartTime.Checked = true;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to remove this student?",
                "Remove Student Registration Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                studentList.Remove(student);
                this.Close();
            }
            else if (dr == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
