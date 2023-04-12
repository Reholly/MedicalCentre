using MedicalCentre.Authentification;
using MedicalCentre.Models;
using System;
using System.Threading.Tasks;

namespace MedicalCentre.Services;

public class AuthentificationService
{
    private IAuthentification authentification = null!;
    private IErrorHandler errorHandler = null!;

    public AuthentificationService(IErrorHandler handler, IAuthentification auth)
    {
        authentification = auth;
        errorHandler = handler;
    }

    /// <summary>
    /// Registration for new Account, it can return null if something wrong.
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Account> RegisterAsync(Account account)
    {  
        return await TryActionAsync(authentification.RegisterUser(account));
    }
    /// <summary>
    /// Log out from Account, it can return null if something wrong.
    /// </summary>
    /// <param name="account"></param>
    /// <returns></returns>
    public async Task<Account> LogOutAsync(Account account)
    {
        return await TryActionAsync(authentification.LogOut(account));
    }
    /// <summary>
    /// Log in Account, it can return null if something wrong.
    /// </summary>
    /// <param username="account"></param>
    /// <param name="password"></param>
    /// <returns></returns>

    public async Task<Account> LogInAsync(string username, string password)
    {
        return await TryActionAsync(authentification.LogIn(username, password));
    }

    private async Task<Account> TryActionAsync(Task<Account> task)
    {
        try
        {
            return await Task.Run(() => task);
        }
        catch(Exception ex)
        {
            errorHandler.HandleError(ex);
            return null;
        }
    }
}