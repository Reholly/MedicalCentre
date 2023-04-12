using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MedicalCentre.Views;

public partial class JuniorPersonalWindow : Window
{
    public JuniorPersonalWindow(Account account, IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new JuniorPersonalViewModel(this, account, services);
    }
}