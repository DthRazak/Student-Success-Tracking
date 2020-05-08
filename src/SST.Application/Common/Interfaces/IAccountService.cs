using System.Security.Claims;
using System.Threading.Tasks;

namespace SST.Application.Common.Interfaces
{
    public interface IAccountService
    {
        public Task CreateStudentAccount(string email, string password, int studentId);

        public Task CreateLectorAccount(string email, string password, int lectorId);

        public Task<ClaimsPrincipal> Login(string email, string password);

        public Task ChangePassword(string user, string oldpassword, string password);
    }
}
