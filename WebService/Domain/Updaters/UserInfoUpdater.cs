using Microsoft.EntityFrameworkCore;
using WebService.Domain.Abstractions;
using WebService.Domain.Entities;

namespace WebService.Domain.Updaters
{
    public class UserInfoUpdater :BaseUpdater, IUserInfoUpdater
    {
        public UserInfoUpdater(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteUser(Guid id)
        {
            if (!ContextAvaible)
            {
                return;
            }
            _context.Users.Remove(new UserInfo() { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<UserInfo> GetUserById(Guid id)
        {
            if (!ContextAvaible)
            {
                return null;
            }
            var tempUser = await _context.Users.FindAsync(id);
            return tempUser;

        }

        public async Task<UserInfo> GetUserByLogin(string login)
        {
            if (!ContextAvaible)
            {
                return null;
            }
            var tempUsers = await _context.Users.ToListAsync();
            for (int i = 0; i < tempUsers.Count; i++)
            {
                if (tempUsers[i].Login == login)
                {
                    return tempUsers[i];
                }
            }
            return null;

        }

        public async Task<List<UserInfo>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task SaveUser(UserInfo user)
        {
            if (user == null)
            {
                return;
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> isUnique(UserInfo user)
        {
            if (user == null)
            {
                return false;
            }
            if (await GetUserByLogin(user.Login) != null)
            {
                return false;
            }
            return true;
        }
    }
}
