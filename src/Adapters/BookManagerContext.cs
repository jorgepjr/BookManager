using Domain;
using Microsoft.EntityFrameworkCore;

namespace Adapters;
public class BookManagerContext : DbContext
{
    public BookManagerContext(DbContextOptions<BookManagerContext> contextOptions): base(contextOptions) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Inventory> Iventories { get; set; }
    public DbSet<CheckOut> CheckOuts { get; set; }

}
