using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Windows;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class DoctorViewModel
    {
        private readonly DoctorWindow window;
        private readonly Account account;
        public ICommand WindowClosingCommand { get; set; }
        public ICommand OpeningMainPageCommand { get; set; }

        public DoctorViewModel(DoctorWindow window, Account account)
        {
            this.window = window;
            this.account = account;
            WindowClosingCommand = new RelayCommandAsync(Close);
            OpeningMainPageCommand = new RelayCommand(OpenMainPage);
        }

        private async Task Close() //метод для LogOut кнопки
        {
            AuthentificationService authentification = new();
            await authentification.LogOut(window, account);
        }

        private void OpenMainPage() => window.MainFrame.Content = new DoctorMainPage(window, account);
    }
}