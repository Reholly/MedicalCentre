using MedicalCentre.Forms.ViewModels;
using System.Windows;

namespace MedicalCentre.Forms
{
    /// <summary>
    /// Логика взаимодействия для EmployeeRegistration.xaml
    /// </summary>
    public partial class EmployeeRegistration : Window
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
            DataContext = new EmployeeRegistrationViewModel(this);
        }
    }
}
