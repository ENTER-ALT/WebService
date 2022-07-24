using WebService.Domain.Entities;

namespace WebService.Domain.Abstractions
{
    public interface IMessageItemUpdater
    {
        public bool ContextAvaible { get; }
        Task<List<MessageItem>> GetMessages();
        Task<MessageItem> GetMessageById(Guid id);
        Task SaveMessage(MessageItem message);
        Task DeleteMessage(Guid id);
    }
}
