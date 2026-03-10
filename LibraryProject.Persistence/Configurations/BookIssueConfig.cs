using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.Persistence.Configurations;

public class BookIssueConfig : IEntityTypeConfiguration<BookIssue>
{
    public void Configure(EntityTypeBuilder<BookIssue> builder)
    {
        builder.ToTable("BookIssue");

        builder.HasKey(b => b.IssueID);
        builder
            .Property(b => b.IssueDate)
            .IsRequired()
            .HasMaxLength(50);
    }
}