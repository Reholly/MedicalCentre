using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using MedicalCentre.Windows;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages
{
    public partial class DoctorMainPage : Page
    {
        public DoctorMainPage(DoctorWindow window, Account account)
        {
            InitializeComponent();
            DataContext = new DoctorMainPageViewModel(this, window, account);
        }
    }
}