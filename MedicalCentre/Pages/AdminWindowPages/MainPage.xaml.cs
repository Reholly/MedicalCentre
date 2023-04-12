using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class MainPage : Page
{
    public MainPage(IServiceCollection services)
    {
        InitializeComponent(); 

        DataContext = new MainPageViewModel(this, services);
    }
}

