namespace Library.DataAccess.Entities
{
    public class BookEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
