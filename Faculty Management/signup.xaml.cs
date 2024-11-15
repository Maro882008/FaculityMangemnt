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
    /// Interaction logic for signup.xaml
    /// </summary>
    public partial class signup : Page
    {
         FacultyEntities db = new FacultyEntities();
        public signup()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            login log = new login();
            if (PasswordBox.Password == ConfirmPasswordBox.Password)
            {
                Student student = new Student();
                string Email = EmailTextBox.Text;
                if (Email.Contains("@gmail.com"))
                {
                    student.email = Email;
                }
                else
                {
                    MessageBox.Show("Please enter email correctly");
                    return;
                }
                if (db.Students.Any(x => x.email == Email)) 
                {
                    MessageBox.Show("aleardy has same email in another account");
                    return;
                }
                student.names = NameTextBox.Text;
                student.pass = PasswordBox.Password;
                db.Students.Add(student);
                db.SaveChanges();
                NavigationService.Navigate(log);
                
                Applaction applaction = new Applaction();

            }
            else
            {
                MessageBox.Show("passwords is not same");
            }

        }
    }
}
