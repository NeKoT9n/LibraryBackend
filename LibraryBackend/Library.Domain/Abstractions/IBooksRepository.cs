using Library.Domain.Model;


namespace Library.Domain.Abstractions
{
    public interface IBooksRepository
    {

        public Task<List<Book>> GetAll();
        public Task<Book> GetBy(Guid id);
        public Task<Guid> Create(Book book);


    }
}