using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Windows;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class MainViewModel
    {
        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        private readonly MainWindow _window;

        public MainViewModel(MainWindow window)
        {
            this._window = window;
            LoginCommand = new RelayCommandAsync(Authentificate);
            CloseCommand = new RelayCommand(Close);
        }

        private async Task Authentificate()
        {
            string login = _window.Login.Text;
            string password = _window.Password.Password;
            AuthentificationService authService = new AuthentificationService();

            try
            {
                Account account = await authService.AuthenticateUser(login, password);
                AccountPrincipal accountPrincipal = Thread.CurrentPrincipal as AccountPrincipal;

                if (accountPrincipal == null)
                {
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");
                }
                accountPrincipal.Identity = new AccountIdentity(account.Username, account.Role);

                await authService.OpenWindowByRole(account);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Close() => _window.Close();
    }
}