using MedicalCentre.ViewModels.OperatorWindowPagesViewModels;
using System;
using System.Windows.Controls;
using MedicalCentre.ViewModels.PagesViewModels.OperatorWindowPagesViewModels;

namespace MedicalCentre.Pages.OperatorPages;

public partial class MainPage : Page
{
    public MainPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new MainPageViewModel(this, serviceProvider);
    }
}
