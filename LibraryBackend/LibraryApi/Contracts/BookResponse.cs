namespace Library.Contracts
{
    public record BookResponse(
        Guid id,
        Guid authorId,
        string title,
        string ImageUrl,
        decimal price
        );
}
