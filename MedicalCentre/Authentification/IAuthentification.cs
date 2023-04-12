using MedicalCentre.Models;
using System.Threading.Tasks;

namespace MedicalCentre.Authentification;

public interface IAuthentification
{
    Task<Account> LogIn(string username, string password);
    Task<Account> RegisterUser(Account account);
    Task<Account> LogOut(Account currentAccount);
}