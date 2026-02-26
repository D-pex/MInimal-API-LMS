using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Books> Book { get; init; }
    public DbSet<BookIssue> BookIssues { get; init; }
    public DbSet<Member> Members { get; init; }
    public DbSet<Category> Category { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var t = typeof(AppDbContext);
        modelBuilder.ApplyConfigurationsFromAssembly(t.Assembly);

        base.OnModelCreating(modelBuilder);
    }
}