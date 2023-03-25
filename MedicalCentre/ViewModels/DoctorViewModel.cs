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
        private readonly DoctorWindow _window;
        private readonly Account _account;
        public ICommand WindowClosingCommand { get; set; }
        public ICommand OpeningMainPageCommand { get; set; }

        public DoctorViewModel(DoctorWindow window, Account account)
        {
            this._window = window;
            this._account = account;
            WindowClosingCommand = new RelayCommandAsync(Close);
            OpeningMainPageCommand = new RelayCommand(OpenMainPage);
        }

        private async Task Close()
        {
            AuthentificationService auth = new();
            await auth.LogOut(_window, _account);
        }

        private void OpenMainPage() => _window.MainFrame.Content = new DoctorMainPage(_window, _account);
    }
}