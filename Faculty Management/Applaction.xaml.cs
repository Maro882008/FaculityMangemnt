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
    /// Interaction logic for Applaction.xaml
    /// </summary>
    public partial class Applaction : Page
    {
        FacultyEntities db = new FacultyEntities();
        public Applaction()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student std = new Student();
           

        }
    }
}
