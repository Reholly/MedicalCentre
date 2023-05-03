using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Controls;
using MedicalCentre.ViewModels.PagesViewModels.AdminWindowPagesViewModels;

namespace MedicalCentre.Pages.AdminWindowPages;

public partial class MainPage : Page
{
    public MainPage(IServiceProvider serviceProvider)
    {
        InitializeComponent(); 

        DataContext = new MainPageViewModel(this, serviceProvider);
    }
}

