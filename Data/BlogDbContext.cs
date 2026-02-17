using hlzn1.DataModels;
using hlzn1.DataModels.Blog;
using Microsoft.EntityFrameworkCore;

namespace hlzn1.Blog.Data;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<BaseEntity>();

        modelBuilder.Entity<BlogPost>(entity => {
            entity.ToTable("BlogPosts", "public");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Preview).IsRequired();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
        });

        modelBuilder.Entity<BlogPostSection>(entity => {
            entity.ToTable("BlogPostSections", "public");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.ContentType).IsRequired();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            entity.Property(e => e.ContentType)
                .HasConversion<string>()
                .HasColumnName("ContentType")
                .HasColumnType("text");
        }); 

        modelBuilder.Entity<BlogPostSection>()
            .Property(b => b.ContentType)
            .HasConversion<string>();
    }

    public DbSet<BlogPost> BlogPosts { get; set; } = null!;
    public DbSet<BlogPostSection> BlogPostSections { get; set; } = null!;
}

