using Microsoft.EntityFrameworkCore;
using Teste8Q.Data;
using Teste8Q.Models;
using Teste8Q.Service.Interfaces;


namespace Teste8Q.Service
{
    public class UserService : IUserService
    {
        public readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.User.ToListAsync();
            return users;
        }

        public async Task<List<User>> AddUser(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
            return await GetAllUsers();
        }

        public async Task<List<User>> UpdateUser(User user, int id)
        {
            var userDb = await _context.User.FindAsync(id);
            if(userDb == null)
            {
                return null;
            }
            userDb.Name = user.Name;
            userDb.Email = user.Email;
            userDb.PersonalNumber = user.PersonalNumber;
            userDb.BusinessNumber = user.BusinessNumber;
            userDb.Company = user.Company;
            await _context.SaveChangesAsync();
            return await GetAllUsers();
        }

        public async Task<List<User>> DeleteUserById(int id)
        {
            var userDb = await _context.User.FindAsync(id);
            if(userDb == null)
            {
                return null;
            }
            _context.User.Remove(userDb);
            await _context.SaveChangesAsync();
            return await GetAllUsers();
        }
        public async Task<List<User>> GetUserByBusinessNumber(string businessNumber)
        {
            var user = await _context.User.Where(u => u.BusinessNumber == businessNumber).ToListAsync();
            if(user is null)
                return null; return user;
        }

        public async Task<List<User>> GetUserByCompany(string company)
        {
            var user = await _context.User.Where(u =>u.Company == company).ToListAsync();
            if (user is null)
                return null; return user;
        }

        public async Task<List<User>> GetUserByEmail(string email)
        {
            var user = await _context.User.Where(u => u.Email.Contains(email)).ToListAsync();
            if (user is null)
                return null; return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user is null)
                return null; return user;
        }

        public async Task<List<User>> GetUserByName(string name)
        {
            var user = await _context.User.Where(u => u.Name == name).ToListAsync();
            if (user is null)
                return null; return user;
        }

        public async Task<List<User>> GetUserByPersonalNumber(string personalNumber)
        {
            var user = await _context.User.Where(u => u.PersonalNumber == personalNumber).ToListAsync();
            if(user is null)
                return null ; return user;
        }
    }
}
