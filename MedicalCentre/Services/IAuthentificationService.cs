using MedicalCentre.Models;
using System.Threading.Tasks;

namespace MedicalCentre.Services
{
    public interface IAuthentificationService
    {
        public async Task<Result> Register(uint id, string password, Employee employee)
        {
            return Result.Success;
        }
        public async Task<Account> Login(uint id, string password)
        {
            return new Account(1000000, null, null);
        }

        public void CheckRole(Role role, Account currentAccount);

    }
}
