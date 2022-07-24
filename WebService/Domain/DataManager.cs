using WebService.Domain.Abstractions;

namespace WebService.Domain
{
    public class DataManager
    {
        public IUserInfoUpdater Users { get; set; }
        public IMessageItemUpdater Messages { get; set; }

        public DataManager(IUserInfoUpdater users, IMessageItemUpdater messages)
        {
            Users = users;
            Messages = messages;
        }
    }
}
