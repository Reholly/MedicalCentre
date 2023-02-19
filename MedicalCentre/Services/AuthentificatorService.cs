using MedicalCentre.Models;
using System;
using System.Threading.Tasks;

namespace MedicalCentre.Services
{
    public class AuthentificatorService
    {
        public Account CurrentAccount { get; set; }
        public bool IsAuthenticated => CurrentAccount != null;
        private IAuthentificationService authentificationService;

        public AuthentificatorService(IAuthentificationService service)
        {
            authentificationService = service;
        }

        public async Task<Account> Login(uint id, string password)
        {
            try
            {
                CurrentAccount = await authentificationService.Login(id, password);
            }
            catch(Exception)
            {
                CurrentAccount = null;
            }

            return CurrentAccount;
        }

        public async Task<Result> Register(uint id, string password, Employee employee)
        {
            return await authentificationService.Register(id, password, employee);
        } 

        public void CheckRole(Role role, Account currentAccount)
        {
            authentificationService.CheckRole(role, currentAccount);
        }
    }
}
