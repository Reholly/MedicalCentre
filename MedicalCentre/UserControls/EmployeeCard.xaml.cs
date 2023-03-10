using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.UserControls.ViewModels;
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

namespace MedicalCentre.UserControls
{
    /// <summary>
    /// Логика взаимодействия для HumanCard.xaml
    /// </summary>
    public partial class EmployeeCard : UserControl
    {
        public EmployeeCard(Employee employee)
        {
            InitializeComponent();
            DataContext = new EmployeeCardViewModel(this, employee);
        }
    }
}
