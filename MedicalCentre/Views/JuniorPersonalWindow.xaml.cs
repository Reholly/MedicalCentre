using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Windows;
using MedicalCentre.ViewModels.MainPagesViewModels;

namespace MedicalCentre.Views;

public partial class JuniorPersonalWindow : Window
{
    public JuniorPersonalWindow(Account account, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new JuniorPersonalWindowViewModel(this, account, serviceProvider);
    }
}