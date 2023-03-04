using System.Windows;
using System.Windows.Input;
using MedicalCentre.ViewModels;

namespace MedicalCentre.Windows
{
    public partial class DoctorWindow : Window
    {
        public DoctorWindow()
        {
            InitializeComponent();
            DataContext = new DoctorViewModel(this);
        }
    }
}