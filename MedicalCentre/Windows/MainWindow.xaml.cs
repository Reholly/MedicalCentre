using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Roles;
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
            db.AddEmployee(new Models.Employee { Id = 1, Name ="Иван", Surname = "Николаев", Patronymic = "Евгеньевич",  Role = new DoctorRole(), Specialization = new Specialization(1, "Проктолог", 10400)});
        }
    }
}
