using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
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

namespace MedicalCentre.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            

            var emp = new Employee(10, "Хрен", "Вай", "Ойой", "Уролог", 10500, new Role("Doctor"));
           
            Database<Employee> database = new Database<Employee>();
            //database.AddItem(emp);
            var cnt = new ApplicationContext();
            cnt.Employees.Add(emp);
            

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}   
