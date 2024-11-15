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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        FacultyEntities db = new FacultyEntities();
        Department department = new Department();
        Student s1 = new Student();
        
        public Admin()
        {
            InitializeComponent();
            var query = from student in db.Students
                        join department in db.Departments
                        on student.Department_Id equals department.Department_Id
                        select new
                        {
                            StudentId = student.ID,
                            StudentName = student.names,
                            Age = student.Age,
                            DepartmentName = department.names  // Using department.names based on your table structure
                        };

            // Bind the query result to the DataGrid
            dataGrid.ItemsSource = query.ToList();
            
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            int Id = int.Parse(sid.Text);
            student = db.Students.First(x => x.ID == Id);
            db.Students.Remove(student);
            db.SaveChanges();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            int studentId = int.Parse(st.Text);
            var query = from student in db.Students
                    join department in db.Departments
                    on student.Department_Id equals department.Department_Id into deptGroup
                    from department in deptGroup.DefaultIfEmpty()
                    where student.ID == studentId
                    select new
                    {
                        StudentId = student.ID,
                        StudentName = student.names,
                        Age = student.Age,
                        DepartmentName = department != null ? department.names : "No Department"
                    };

        // Bind the result to the DataGrid
        dataGrid.ItemsSource = query.ToList();
        }
    }
}
