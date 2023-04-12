using MedicalCentre.Models;
using MedicalCentre.ViewModels.DoctorWindowPagesViewModels;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MedicalCentre.Pages.DoctorWindowPages;

public partial class DoctorMainPage : Page
{
    public DoctorMainPage(DoctorWindow window, Account account, IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new DoctorMainPageViewModel(this, window, account, services);
    }
}