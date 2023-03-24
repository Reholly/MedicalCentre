using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System.Windows;

namespace MedicalCentre.Windows
{
    public partial class JuniorPersonalWindow : Window
    {
        public JuniorPersonalWindow(Account account)
        {
            InitializeComponent();
            DataContext = new JuniorPersonalViewModel(this, account);
            //frame.Content = new JuniorPersonalWindow(account);
        }
    }
}