using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedicalCentre.Authentification;

public class DefaultAuthentification : IAuthentification
{
    private IRepository<Account> accountRepository;
    public DefaultAuthentification(IRepository<Account> accountRepository)
    {
        this.accountRepository = accountRepository;
    }

    public async Task<Account> LogIn(string username, string password)
    {
       
        List<Account> accounts = await Task.Run( ()=> accountRepository.GetTableAsync());
        Account? account = accounts.FirstOrDefault(o => o.Username == username);

        if (account == null)
        {
            throw new UnauthorizedAccessException($"Доступ с адреса: {GetCurrentUserIp()} запрещен. Пользователь не существует или введены некорректные данные.");
        }
        if (account.IsOnline)
        {
            throw new UnauthorizedAccessException($"Попытка входа в аккаунт {account.Username} отклонена. Пользователь уже в сети.");
        }
        if (account != null && account.Password == CalculateHash(password, account.Id.ToString()))
        {
            await LoggerService.CreateLog($"Доступ разрешен. Пользователь {account.Username} вошел в систему.", true);
            account.IsOnline = true;
            await accountRepository.UpdateItemAsync(account);

            AccountPrincipal accountPrincipal = Thread.CurrentPrincipal as AccountPrincipal;

            if (accountPrincipal == null)
            {
                throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");
            }
            accountPrincipal.Identity = new AccountIdentity(account.Username, account.Role);

            return account;
        }

        throw new UnauthorizedAccessException("Доступ запрещен. Неверные данные.");
    }

    public async Task<Account> LogOut(Account currentAccount)
    {
        currentAccount.IsOnline = false;
        await accountRepository.UpdateItemAsync(currentAccount);
        await LoggerService.CreateLog($"Пользователь {currentAccount.Username} вышел из системы.", true);
        return currentAccount;
    }

    public async Task<Account> RegisterUser(Account account)
    {
        account.Password = CalculateHash(account.Password, account.Id.ToString());
            
        List<Account> accounts = new();

        if (accounts.FirstOrDefault(o => o.Username == account.Username) != null)
        {
            throw new InvalidOperationException($"Аккаунт с именем: {account.Username} уже существует.");
        }

        await accountRepository.AddItemAsync(account);

        return account;
    }

    private string CalculateHash(string clearTextPassword, string salt)
    {
        byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
        HashAlgorithm algorithm = new SHA512Managed();
        byte[] hash = algorithm.ComputeHash(saltedHashBytes);
        return Convert.ToBase64String(hash);
    }

    private string GetCurrentUserIp()
    {
        string host = System.Net.Dns.GetHostName();
        System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
        return ip.ToString();
    }
}

public enum Roles
{
    Doctor = 1,
    Admin = 2,
    Operator = 3,
    JuniorPersonal = 4
}
