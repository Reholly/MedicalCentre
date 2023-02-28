using System.Windows;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;

namespace MedicalCentre.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
            InitializeComponent();
            DataContext = new MainViewModel(this);
        } 
    }
}   
