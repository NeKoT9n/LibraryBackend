using Library.Domain.Model;

namespace Library.Domain.Factory
{
    public class BookFactory : IBookFactory
    {
        public Book Create(Guid id, Guid authorId, string title, decimal price, string imageUrl)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Title must not be empty");

            if (string.IsNullOrEmpty(imageUrl))
                throw new ArgumentException("Image url must not be empty");

            return new Book(id, title, authorId, price, imageUrl);
        }
    }

    public interface IBookFactory
    {
        public Book Create(Guid id, Guid authorId, string title, decimal price, string imageUrl);
    }
}
