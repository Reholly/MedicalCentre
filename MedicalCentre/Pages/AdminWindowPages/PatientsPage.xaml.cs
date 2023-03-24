using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages
{
    /// <summary>
    /// Логика взаимодействия для Patients.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public PatientsPage()
        {
            InitializeComponent();
            DataContext = new PatientsViewModel(this);
        }
    }
}
