using Books_server.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Books_server.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
