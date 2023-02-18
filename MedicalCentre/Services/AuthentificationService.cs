using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Windows;
using System;
using System.Threading.Tasks;

namespace MedicalCentre.Services
{
    public class AuthentificationService : IAuthentificationService
    {
        public async Task<Result> Register(uint id, string password, Employee employee)
        {
            Database<Account> accountDatabase = new Database<Account>();
            try
            {
                accountDatabase.AddItem(employee);
                LoggerService.CreateLog($"Register new Account:{id}:{password}", true);
            }
            catch (Exception ex)
            {
                LoggerService.CreateLog(ex.Message, false);
            }

            if(id == accountDatabase.GetTable().Result.Find(p => p.Id == id).Id)
            {
                return Result.UsernameAlreadyExist;

            }
            Database<Employee> employeeDatabase = new Database<Employee>();
            employeeDatabase.AddItem(employee);
            Account account = new Account(id, employee, password);
            accountDatabase.AddItem(account);

            return Result.Success;
        }

        public async Task<Account> Login(uint id, string password)
        {
            Database<Account> accountDatabase = new Database<Account>();

            try
            {
                Account account = accountDatabase.GetItemById(id).Result;
                if(account.Password == password)
                {
                    LoggerService.CreateLog($"Login user {account.Id}", true);
                }
                return account;
                
            }
            catch(Exception ex)
            {
                LoggerService.CreateLog(ex.Message, false);
                return null;
            }
        }

        public void CheckRole(Role role, Account currentAccount)
        {
            switch (role.Title)
            {
                case "Doctor":
                    DoctorWindow doctor = new();
                    doctor.Show();
                    LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                case "SystemAdmin":
                    SystemAdminWindow sysAdmin = new();
                    sysAdmin.Show();
                    LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                case "Admin":
                    AdminWindow admin = new();
                    admin.Show();
                    LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                case "Operator":
                    OperatorWindow operatorWindow = new();
                    operatorWindow.Show();
                    LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                case "JuniorPersonal":
                    JuniorPersonalWindow juniorPersonal = new JuniorPersonalWindow();
                    juniorPersonal.Show();
                    LoggerService.CreateLog($"Вошел в систему {currentAccount.Id}", true);
                    break;
                default:
                    throw new Exception("Wrong role, please, try later and call System Admin");
                    LoggerService.CreateLog("Неверно указана роль", false);
                    break;
            }
        }
    }
    public enum Result
    {
        Success,
        UsernameAlreadyExist,
        WrongPassword,
        WrongUsername
    }
}
