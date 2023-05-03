using System;
using System.Windows.Controls;
using MedicalCentre.ViewModels.PagesViewModels.JuniorPersonalWindowPagesViewModel;

namespace MedicalCentre.Pages.JuniorPersonalWindowPages;

public partial class StoragePage : Page
{
    public StoragePage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new JuniorPersonalMainPageViewModel(serviceProvider);
    }
}