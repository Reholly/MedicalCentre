using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Windows;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class DoctorViewModel
    {
        private readonly DoctorWindow window;
        private readonly Account account;
        public ICommand WindowClosingCommand { get; set; }

        public DoctorViewModel(DoctorWindow window, Account account)
        {
            this.window = window;
            this.account = account;
            WindowClosingCommand = new RelayCommand(Close);
        }

        private void Close() //метод для LogOut кнопки
        {
            new AuthentificationService().LogOut(window, account);
            window.Close();
        }
    }
}