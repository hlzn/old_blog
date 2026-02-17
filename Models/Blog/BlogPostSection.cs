using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using hlzn1.APIModels.Blog;
using Microsoft.EntityFrameworkCore;

namespace hlzn1.DataModels.Blog;


[Table("BlogPostSections", Schema = "public")]
[Comment("Table storing sections of blog posts")]
public class BlogPostSection : BaseEntity
{
    [Comment("The order of the section in the blog post")]
    public int Index { get; set; }

    [Comment("The content of the blog post section")]
    public string Content { get; set; } = string.Empty;

    [Comment("The type of content in the blog post section")]
    public BlogPostSectionContentType ContentType { get; set; }

    [ForeignKey("BlogPost")]
    [Comment("The ID of the associated blog post")]
    public int BlogPostId { get; set; }

    public virtual BlogPost BlogPost { get; set; } = null!;
}