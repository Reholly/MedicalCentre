using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class MainPage : Page
{
    public MainPage(IServiceProvider serviceProvider)
    {
        InitializeComponent(); 

        DataContext = new MainPageViewModel(this, serviceProvider);
    }
}

