using MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MedicalCentre.Pages.GeneralPages;

public partial class StoragePage : Page
{
    public StoragePage(IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new JuniorPersonalMainPageViewModel(services);
    }
}