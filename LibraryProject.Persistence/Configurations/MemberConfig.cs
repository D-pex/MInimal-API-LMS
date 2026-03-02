using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryProject.Persistence.Configurations;

public class MemberConfig : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.ToTable("Member"); // here it say's that it can represent my table if i use different table name "as sir said".
        
        builder.HasKey(m => m.MemberId); // Primary key  
        builder.Property(m => m.MemberName)
            .IsRequired()
            .HasMaxLength(50);
    }
}