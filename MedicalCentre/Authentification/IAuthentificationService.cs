using MedicalCentre.Models;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCentre.Authentification
{
    internal interface IAuthentificationService
    {
        Task<Account> AuthenticateUser(string username, string password);
        Task<Account> RegisterUser(Account account);
        Task LogOut(Window window, Account currentAccount);
        Task OpenWindowByRole(Account account);
    }
}
