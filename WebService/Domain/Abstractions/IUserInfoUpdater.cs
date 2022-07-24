using WebService.Domain.Entities;

namespace WebService.Domain.Abstractions
{
    public interface IUserInfoUpdater
    {
        public bool ContextAvaible { get; }
        Task<List<UserInfo>> GetUsers();
        Task<UserInfo> GetUserById(Guid id);
        Task<UserInfo> GetUserByLogin(string login);
        Task SaveUser(UserInfo user);
        Task DeleteUser(Guid id);
        Task<bool> isUnique(UserInfo user);
    }
}
