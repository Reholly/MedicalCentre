using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Windows;

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