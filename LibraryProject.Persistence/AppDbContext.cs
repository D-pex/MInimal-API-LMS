using Microsoft.EntityFrameworkCore;


namespace LibraryProject.Persistence;


public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Books> Books { get; init ; }
    public DbSet<BookIssue> BookIssues { get; init; }
    public DbSet<Member> Members { get; init; }
    public DbSet<Category> Categories { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Type t = typeof(AppDbContext);
        modelBuilder.ApplyConfigurationsFromAssembly(t.Assembly);

        base.OnModelCreating(modelBuilder);
    }
}