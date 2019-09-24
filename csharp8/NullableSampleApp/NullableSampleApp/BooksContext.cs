using Microsoft.EntityFrameworkCore;

namespace NullableSampleApp
{
#nullable disable
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
#nullable restore
}
