using Library.Domain.Model;

namespace Library.Domain.Abstractions
{
    public interface ILibraryService
    {
        Task<Guid> AddBook(Book book);
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBook(Guid id);
    }
}