using Microsoft.EntityFrameworkCore;


namespace LibraryProject.Persistence;


public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Books> Books { get; set; }
    public DbSet<BookIssue> BookIssues { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Type t = typeof(AppDbContext);
        modelBuilder.ApplyConfigurationsFromAssembly(t.Assembly);

        base.OnModelCreating(modelBuilder);
    }
}