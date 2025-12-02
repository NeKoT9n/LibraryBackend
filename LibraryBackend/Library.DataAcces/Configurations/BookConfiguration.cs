using Library.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder
                .HasKey(entity => entity.Id);

            builder
                .Property(entity => entity.Title)
                .IsRequired();

            builder
                .Property(entity => entity.AuthorId)
                .IsRequired();

            builder
                .Property(entity => entity.ImageUrl)
                .IsRequired();

        }
    }
}
