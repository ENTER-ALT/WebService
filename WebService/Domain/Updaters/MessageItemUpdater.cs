using WebService.Domain.Abstractions;
using WebService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebService.Domain.Updaters
{
    public class MessageItemUpdater :BaseUpdater, IMessageItemUpdater
    {
        public MessageItemUpdater(AppDbContext context) : base(context)
        {
        }

        public async Task DeleteMessage(Guid id)
        {
            if (!ContextAvaible)
            {
                return;
            }
            _context.Messages.Remove(new MessageItem() { Id = id });
            await _context.SaveChangesAsync();
        }

        public async Task<MessageItem> GetMessageById(Guid id)
        {
            if (!ContextAvaible)
            {
                return null;
            }
            var tempMessage = await _context.Messages.FindAsync(id);
            return tempMessage;

        }

        public async Task<List<MessageItem>> GetMessages()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task SaveMessage(MessageItem message)
        {
            if (message == null)
            {
                return;
            }
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
