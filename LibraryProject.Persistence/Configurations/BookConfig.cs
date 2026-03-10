using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.Persistence.Configurations;

public  sealed class BookConfig : IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b => b.BookId);
        builder
            .Property(b => b.BookName)
            .IsRequired()
            .HasMaxLength(50);
    }
}