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

            DatabaseInteraction db = new DatabaseInteraction();

            using (ApplicationContext context = new ApplicationContext())
            {
                foreach(var d in context.Employees.ToList())
                {
                    MessageBox.Show($"{d.Id} - {d.Name} ");
                }
                foreach(var b in context.Roles.ToList())
                {
                    MessageBox.Show(b.Id.ToString());
                }
                
            }

        }
    }
}   
