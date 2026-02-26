using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.Persistence.Configurations;

public class BookConfig :  IEntityTypeConfiguration<Books>
{
    public void Configure(EntityTypeBuilder<Books> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(s => s.BookId);
        builder
            .Property(s => s.BookName)
            .IsRequired()
            .HasMaxLength(50);

        
    }
}