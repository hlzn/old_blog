using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace hlzn1.DataModels.Blog;

[Table("BlogPosts", Schema = "public")]
[Comment("Table storing blog posts")]
public class BlogPost : BaseEntity
{
    
    [Comment("The title of the blog post")]
    public string Title { get; set; } = string.Empty;
    
    [Comment("Preview of the blog post")]
    [Column(TypeName = "text")]
    [MaxLength(500)]
    public string Preview { get; set; } = string.Empty;

    [Column(TypeName = "text")]
    [Comment("The preview size image of the blog post")]
    public string? PreviewImageSource { get; set; }
    
    [Comment("When the blog post was published")]
    public DateTime? PublishedAt { get; set; }
    
    [Comment("Is the blog post public?")]
    public bool IsPublic { get; set; }

    // blog post tags using jsonb
    [Comment("The tags of the blog post")]
    public List<string> Tags { get; set; } = new List<string>();

}