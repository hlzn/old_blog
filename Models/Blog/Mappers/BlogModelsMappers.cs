using hlzn1.Constants.Blog;
using hlzn1.DataModels.Blog;
using hlzn1.DTOs.Blog;
using Sqids;

namespace hlzn1.Mappers.Blog;

public static class BlogModelsMappers
{
    public static BlogPostDTO AsBlogPostDTO(this BlogPost blogPost, List<BlogPostSection> sections)
    {
        var squids = new SqidsEncoder<int>(new() { MinLength = 5, Alphabet = BlogConstants.SqidsAlphabet });
        return new BlogPostDTO
        {
            Id = squids.Encode(blogPost.Id),
            Title = blogPost.Title,
            Preview = blogPost.Preview,
            CreatedAt = blogPost.CreatedAt.ToShortDateString(),
            Sections = sections.AsBlogPostSectionDTOs(),
            Tags = blogPost.Tags,
            PreviewImageSource = blogPost.PreviewImageSource
        };
    }

    public static List<BlogPostSectionDTO> AsBlogPostSectionDTOs(this List<BlogPostSection> sections)
    {
        return sections.Select(section => new BlogPostSectionDTO
        {
            Index = section.Index,
            Content = section.Content,
            CreatedAt = section.CreatedAt,
            ContentTypeId = section.ContentType
        }).ToList();
    }
}