using MedicalCentre.ViewModels;
using System.Windows;

namespace MedicalCentre.Views
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