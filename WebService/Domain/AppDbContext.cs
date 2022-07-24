using Microsoft.EntityFrameworkCore;
using WebService.Domain.Entities;

namespace WebService.Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserInfo> Users { get; set; }
        public DbSet<MessageItem> Messages { get; set; }
    }
}
