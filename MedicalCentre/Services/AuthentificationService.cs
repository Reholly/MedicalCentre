using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Windows;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCentre.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        public async Task<Result> Register(uint id, string password, Employee employee)
        {
            Database<Account> accountDatabase = new Database<Account>();
            try
            {
                await Task.Run(() => accountDatabase.AddItemAsync(new Account(id, employee.Id, password)));
                await LoggerService.CreateLog($"Register new Account:{id}:{password}", true);
            }
            catch (Exception ex)
            {
                await LoggerService.CreateLog(ex.Message, false);
                return Result.Error;
            }

            Database<Employee> employeeDatabase = new Database<Employee>();
            await employeeDatabase.AddItemAsync(employee);
            Account account = new Account(id, employee.Id, password);
            await accountDatabase.AddItemAsync(account);

            return Result.Success;
        }

        public async Task<Account> Login(uint id, string password)
        {
            Database<Account> accountDatabase = new Database<Account>();

            try
            {
                Account account = await accountDatabase.GetItemByIdAsync(id);
                if(account.Password == password)
                {
                    await LoggerService.CreateLog($"Login user {account.Id}", true);
                    return account;
                }

                return null;
            }
            catch(Exception ex)
            {
                await LoggerService.CreateLog(ex.Message, false);
                return null;
            }
        }

        public async Task CheckRole(Role role, Account currentAccount)
        {
            switch (role.Title)
            {
                case "Doctor":
                    DoctorWindow doctor = new();
                    doctor.Show();
                    await LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                case "SystemAdmin":
                    SystemAdminWindow sysAdmin = new();
                    sysAdmin.Show();
                    await LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                case "Admin":
                    AdminWindow admin = new();
                    admin.Show();
                    await LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                case "Operator":
                    OperatorWindow operatorWindow = new();
                    operatorWindow.Show();
                    await LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                case "JuniorPersonal":
                    JuniorPersonalWindow juniorPersonal = new JuniorPersonalWindow();
                    juniorPersonal.Show();
                    await LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                default:
                    await LoggerService.CreateLog("Неверно указана роль", false);
                    MessageBox.Show("Проблемы с получением роли. Перезайдите и выполните вход заново или свяжитесь с сис.админом");
                    break;
            }
        }
    }
    public enum Result
    {
        Success,
        UsernameAlreadyExist,
        WrongPassword,
        WrongUsername,
        Error
    }
}
