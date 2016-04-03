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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentRegistrationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> mockAdminList;
        int attempt;

        public MainWindow()
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

        private void buttonSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (attempt == 3)
            {
                MessageBox.Show("Username and password does not exist.", "Student Registration Login Warning");
                MessageBox.Show("You have reached maximum three unsuccessful attempts.", "Student Registration Login Warning");
                Environment.Exit(0);
            }
            if (string.IsNullOrEmpty(textBoxUsername.Text) || textBoxUsername.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please enter username", "Student Registration Login Warning");
            }
            else if (string.IsNullOrEmpty(passwordBox.Password))
            {
                MessageBox.Show("Please enter password", "Student Registration Login Warning");
            }
            else
            {
                Person p = ValidateUser(textBoxUsername.Text, passwordBox.Password);
                if (!object.ReferenceEquals(null, p))
                {
                    //this.Hide();
                    StudentRegistrationMain mainWindow = new StudentRegistrationMain();
                    mainWindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    attempt++;
                    MessageBox.Show("Username and password does not exist.", "Student Registration Login Warning");
                }
            }
        }
    
    }
}
