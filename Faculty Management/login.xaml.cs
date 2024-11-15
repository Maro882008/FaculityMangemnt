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

namespace Faculty_Management
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Page
    {
        FacultyEntities db = new FacultyEntities();
        public login()
        {
            InitializeComponent();
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            signup signup1 = new signup();
            NavigationService.Navigate(signup1);
        }

        private void log_Click(object sender, RoutedEventArgs e)
        {
            string user = "Admin";
            string password = "admin@123";
            if((et.Text == "" && pt.Password == "") || (et.Text == ""|| pt.Password == ""))
            {
                MessageBox.Show("please enter password or user name");
                return;
            }
            if((user == et.Text) && (password == pt.Password))
            {
                Admin admin = new Admin();
                MessageBox.Show("log in sucessfuly");
                NavigationService.Navigate(admin);
            }
            else if (db.Students.Any(x => x.email == et.Text))
            {
                Applaction applaction = new Applaction();
                NavigationService.Navigate(applaction);
                MessageBox.Show("log in sucessfuly");
            }
            else
            {
                MessageBox.Show("user name or password not correct");
            }
        }
    }
}
