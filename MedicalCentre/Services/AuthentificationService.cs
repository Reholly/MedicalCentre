using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
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

            if(id == accountDatabase.GetTable().Find(p => p.Id == id).Id)
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
                Account account = accountDatabase.GetItemById(id);
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
    }
    public enum Result
    {
        Success,
        UsernameAlreadyExist,
        WrongPassword,
        WrongUsername
    }
}
