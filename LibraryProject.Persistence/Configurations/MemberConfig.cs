using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.Persistence.Configurations;

public class MemberConfig : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Member"); // Matches your table name
        builder.HasKey(m => m.MemberId); // Primary key
        builder.Property(m => m.MemberName)
            .IsRequired()
            .HasMaxLength(50);
    }
}