using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Windows;

namespace MedicalCentre.Views;

public partial class JuniorPersonalWindow : Window
{
    public JuniorPersonalWindow(Account account, IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new JuniorPersonalViewModel(this, account, serviceProvider);
    }
}