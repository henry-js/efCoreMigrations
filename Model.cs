using Microsoft.EntityFrameworkCore;

namespace efCoreMigrations;
internal class BlogContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=Blogs.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().Property(p => p.Title)
            .IsRequired();
    }
}

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string? Content { get; set; }
}