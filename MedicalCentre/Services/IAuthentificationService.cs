using MedicalCentre.Models;
using System.Threading.Tasks;

namespace MedicalCentre.Services
{
    public interface IAuthentificationService
    {
        public async Task<Result> Register(uint id, string password, Employee employee)
        {
            return await Task.Run(() => Result.Success);
        }
        public async Task<Account> Login(uint id, string password)
        {
            return await Task.Run(() => new Account(1000000, 0, null));
        }

        public async Task CheckRole(Role role, Account currentAccount)
        {

        }

    }
}
