namespace hlzn1.DTOs.Blog;

public class BlogPostDTO
{
    public required string Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Preview { get; set; } = string.Empty;

    public string? PreviewImageSource { get; set; }

    public List<string> Tags { get; set; } = new List<string>();
    public List<BlogPostSectionDTO> Sections { get; set; } = new List<BlogPostSectionDTO>();
    public required string CreatedAt { get; set; }
}