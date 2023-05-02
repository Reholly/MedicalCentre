using MedicalCentre.ViewModels.PagesViewModels.OperatorWindowPagesViewModels;
using System;
using System.Windows.Controls;

namespace MedicalCentre.Pages.OperatorPages;

public partial class MainPage : Page
{
    public MainPage(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new MainPageViewModel(serviceProvider);
    }
}
