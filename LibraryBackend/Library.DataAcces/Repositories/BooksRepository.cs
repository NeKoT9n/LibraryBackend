using Library.DataAccess.Entities;
using Library.Domain.Abstractions;
using Library.Domain.Factory;
using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Library.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BooksDbContext _context;
        private readonly IBookFactory _bookFactory;

        public BooksRepository(BooksDbContext context, IBookFactory bookFactory)
        {
            _context = context;
            _bookFactory = bookFactory;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity()
            {
                Id = book.Id,
                AuthorId = book.AuthorId,
                Title = book.Title,
                Price = book.Price,
                ImageUrl = book.ImageUrl

            };

            await _context.Books.AddAsync(bookEntity);
            await _context.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<List<Book>> GetAll()
        {
            var bookEntities = await _context.Books
                .AsNoTracking().ToListAsync();

            var books = bookEntities
                .Select(entity =>
                    _bookFactory.Create(
                        entity.Id,
                        entity.AuthorId,
                        entity.Title,
                        entity.Price,
                        entity.ImageUrl))
                .ToList();

            return books;
        }

        public async Task<Book> GetBy(Guid id)
        {
            var entity = await _context.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(entity => entity.Id == id)
                ?? throw new KeyNotFoundException($"Book {id} not found");

            var book = _bookFactory
                .Create(
                    entity.Id,
                    entity.AuthorId,
                    entity.Title,
                    entity.Price,
                    entity.ImageUrl);

            return book;
        }
    }
}
