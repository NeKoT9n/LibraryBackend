namespace Library.Domain.Model
{
    public class Book
    {
        public Book(Guid id, string title, Guid authorId, decimal price, string imageUrl)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
            Price = price;
            ImageUrl = imageUrl;
        }

        public Guid Id { get; }
        public string Title {  get; } = string.Empty;

        public Guid AuthorId;

        public decimal Price { get; }
        public string ImageUrl { get; } = string.Empty;

    }
}
