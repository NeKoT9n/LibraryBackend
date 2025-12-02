using Library.Domain.Abstractions;
using Library.Domain.Model;

namespace Library.Application.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IBooksRepository _repository;

        public LibraryService(IBooksRepository repository)
            => _repository = repository;

        public async Task<List<Book>> GetAllBooks()
        {
            return await _repository.GetAll();
        }

        public async Task<Book> GetBook(Guid id)
        {
            return await _repository.GetBy(id);
        }

        public async Task<Guid> AddBook(Book book)
        {
            return await _repository.Create(book);
        }

    }
}
