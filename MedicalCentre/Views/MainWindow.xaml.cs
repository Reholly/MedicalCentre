using MedicalCentre.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace MedicalCentre.Views;

public partial class MainWindow : Window
{
    public MainWindow(IServiceCollection services)
    {
        InitializeComponent();
        DataContext = new MainViewModel(this, services);
    }
}