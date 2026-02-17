namespace hlzn1.DTOs.Blog;

public class BlogPostCreateDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Preview { get; set; } = string.Empty;
    public string? PreviewImageSource { get; set; }
    public List<BlogPostSectionDTO> Sections { get; set; } = new List<BlogPostSectionDTO>();
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}