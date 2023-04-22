using MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModel;
using System;
using System.Windows.Controls;

namespace MedicalCentre.Pages.GeneralPages;

public partial class StoragePage : Page
{
    public StoragePage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new JuniorPersonalMainPageViewModel(serviceProvider);
    }
}