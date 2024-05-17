using Teste8Q.Models;

namespace Teste8Q.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<List<User>> AddUser(User user);
        Task<List<User>> UpdateUser(User user, int id);
        Task<List<User>> DeleteUserById(int id);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUserByName(string name);
        Task<List<User>> GetUserByEmail(string email);
        Task<List<User>> GetUserByCompany(string company);
        Task<List<User>> GetUserByBusinessNumber(string businessNumber);
        Task<List<User>> GetUserByPersonalNumber(string personalNumber);
    }
}
