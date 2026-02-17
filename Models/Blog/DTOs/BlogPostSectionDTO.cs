using hlzn1.APIModels.Blog;

namespace hlzn1.DTOs.Blog;

public class BlogPostSectionDTO
{
    public int Index { get; set; }
    public BlogPostSectionContentType ContentTypeId { get; set; }
    public string Content { get; set; } = string.Empty;
    
}