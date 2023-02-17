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

        public async Task<bool> Login(uint id, string password)
        {
            bool success = true;

            try
            {
                CurrentAccount = await authentificationService.Login(id, password);
            }
            catch(Exception)
            {
                success = false;
            }

            return success;
        }

        public async Task<Result> Register(uint id, string password, Employee employee)
        {
            return await authentificationService.Register(id, password, employee);
        } 
    }
}
