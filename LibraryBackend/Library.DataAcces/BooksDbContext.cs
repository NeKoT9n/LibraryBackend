using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options)
            : base(options) { }

        public DbSet<BookEntity> Books { get; set; }
    }
}
