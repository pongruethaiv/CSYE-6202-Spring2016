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
    public partial class LoginForm : Form
    {
        List<Person> mockAdminList;
        int attempt;

        public LoginForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            LoadUserWithMockData();
            attempt = 1;
        }

        private void LoadUserWithMockData()
        {
            mockAdminList = new List<Person>()
            {
                new Admin("John","Smith","admin", "admin"),
                new Admin("Barry","Allen","demouser", "password"),
            };
        }

        private Person ValidateUser(string username, string password)
        {
            foreach (Admin p in mockAdminList)
            {
                if (p.Username.Equals(username) && p.Password.Equals(password))
                {
                    return p;
                }
            }
            return null;
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            if (attempt == 3)
            {
                MessageBox.Show("Username and password does not exist.", "Student Registration Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("You have reached maximum three unsuccessful attempts.", "Student Registration Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
            if (string.IsNullOrEmpty(textBoxUsername.Text) || textBoxUsername.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter username", "Student Registration Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please enter password", "Student Registration Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Person p = ValidateUser(textBoxUsername.Text, textBoxPassword.Text);
                if (!object.ReferenceEquals(null, p))
                {
                    //this.Hide();
                    StudentRegistrationForm mainForm = new StudentRegistrationForm();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    attempt++;
                    MessageBox.Show("Username and password does not exist.", "Student Registration Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
