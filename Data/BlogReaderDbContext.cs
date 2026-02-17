using hlzn1.DataModels.Blog;
using Microsoft.EntityFrameworkCore;

namespace hlznet.Data;

public class BlogReaderDbContext : DbContext
{
    public BlogReaderDbContext(DbContextOptions<BlogReaderDbContext> options) : base(options)
    {
    }

    public DbSet<BlogPost> BlogPosts { get; set; } = null!;
    public DbSet<BlogPostSection> BlogPostSections { get; set; } = null!;
}