namespace WebService.Domain.Updaters
{
    public abstract class BaseUpdater
    {
        protected readonly AppDbContext _context;
        protected BaseUpdater(AppDbContext context)
        {
            _context = context;
        }

        public bool ContextAvaible => _context != null && _context.Database.CanConnect();
    }
}
