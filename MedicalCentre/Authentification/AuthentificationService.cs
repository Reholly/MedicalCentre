using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.Windows;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MedicalCentre.Authentification
{
    internal class AuthentificationService : IAuthentificationService
    {
        public async Task<Account> AuthenticateUser(string username, string password)
        {
            ContextRepository<Account> accDb = new();
            List<Account> accounts = await accDb.GetTableAsync();
            Account? account = accounts.FirstOrDefault(o => o.Username == username);

            if (account == null)
            {
                LoggerService.CreateLog($"Доступ с адреса: {GetCurrentUserIp()} запрещен", false);
                throw new UnauthorizedAccessException("Доступ запрещен. Пользователя не существует или введенные данные не верны.");              
            }
            if (account.IsOnline)
            {
                LoggerService.CreateLog($"Попытка входа в аккаунт {account.Username} отклонена. Пользователь уже в сети.", false);
                throw new UnauthorizedAccessException("Пользователь уже в сети");
            }
            if (account != null && account.Password == CalculateHash(password, account.Id.ToString()))
            {
                LoggerService.CreateLog($"Доступ разрешен. Пользователь {account.Username} вошел в систему.", true);
                account.IsOnline = true;
                accDb.UpdateItemAsync(account);
                return account;
            }

            throw new UnauthorizedAccessException("Доступ запрещен. Неверные данные.");
        }

        public async Task LogOut(Window window, Account currentAccount)
        {
            ContextRepository<Account> accDb = new();           
            currentAccount.IsOnline = false;
            accDb.UpdateItemAsync(currentAccount);
            LoggerService.CreateLog($"Пользователь {currentAccount.Username} вышел из системы.", true);
            window.Close();          
        }

        public async Task OpenWindowByRole(Account currentAccount)
        {
            switch (currentAccount.Role)
            {
                case "Doctor":
                    DoctorWindow doctor = new DoctorWindow(currentAccount);
                    doctor.Show();
                    break;            
                case "Admin":
                    AdminWindow admin = new AdminWindow(currentAccount);
                    admin.Show();
                    break;
                case "Operator":
                    OperatorWindow operatorWindow = new OperatorWindow(currentAccount);
                    operatorWindow.Show();
                    break;
                case "JuniorPersonal":
                    JuniorPersonalWindow juniorPersonal = new JuniorPersonalWindow();
                    juniorPersonal.Show();
                    break;
                default:
                    await LoggerService.CreateLog("Неверно указана роль.", false);
                    MessageBox.Show("Проблемы с получением роли. Перезайдите и выполните вход заново или свяжитесь с сис.админом");
                    break;
            }
        }

        public async Task<Account> RegisterUser(Account account)
        {
            account.Password = CalculateHash(account.Password, account.Id.ToString());
            ContextRepository<Account> accDb = new();
            List<Account> accounts = new();

            if(accounts.FirstOrDefault(o => o.Username == account.Username) != null)
            {
                throw new Exception($"Аккаунт с именем: {account.Username} уже существует.");
            }

            accDb.AddItemAsync(account);

            return account;
        }

        public string CalculateHash(string clearTextPassword, string salt)
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
}
