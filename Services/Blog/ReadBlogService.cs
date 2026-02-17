using hlzn1.APIModels;
using hlzn1.Constants.Blog;
using hlzn1.Blog.Data;
using hlzn1.DataModels.Blog;
using hlzn1.DTOs.Blog;
using hlzn1.Mappers.Blog;
using Microsoft.EntityFrameworkCore;
using Sqids;

namespace hlzn1.Services.Blog;

public interface IReadBlogService
{
    public Task<BasicResponse<BlogPostDTO>> GetBlogPostAsync(int id);
    public Task<BasicResponse<BlogPostDTO>> GetBlogPostAboutAsync();
    public Task<BasicResponse<List<BlogPostDTO>>> GetLatestBlogPostsAsync(BasicCollectionRequest request);
}


public class ReadBlogService : IReadBlogService
{
    private readonly BlogDbContext _blogReaderDb;
    public ReadBlogService(BlogDbContext blogReaderDb)
    {
        _blogReaderDb = blogReaderDb;
    }

    public async Task<BasicResponse<BlogPostDTO>> GetBlogPostAboutAsync()
    {
        var blogPost = await _blogReaderDb.BlogPosts
            .Where(x => x.Title == "About Me")
            .FirstOrDefaultAsync();

        if (blogPost == null)
        {
            return new BasicResponse<BlogPostDTO>
            {
                Success = false,
                Message = "Blog post not found."
            };
        }

        var sections = await _blogReaderDb.BlogPostSections
            .Where(x => x.BlogPostId == blogPost.Id)
            .ToListAsync();

        return new BasicResponse<BlogPostDTO>
        {
            Success = true,
            Data = blogPost.AsBlogPostDTO(sections)
        };
    }

    public async Task<BasicResponse<BlogPostDTO>> GetBlogPostAsync(int id)
    {
        var blogPost = await _blogReaderDb.BlogPosts.FindAsync(id);
        if (blogPost == null)
        {
            return new BasicResponse<BlogPostDTO>
            {
                Success = false,
                Message = "Blog post not found."
            };
        }

        var sections = await _blogReaderDb.BlogPostSections
            .Where(x => x.BlogPostId == id)
            .ToListAsync();

        return new BasicResponse<BlogPostDTO>
        {
            Success = true,
            Data = blogPost.AsBlogPostDTO(sections)
        };
    }

    public async Task<BasicResponse<List<BlogPostDTO>>> GetLatestBlogPostsAsync(BasicCollectionRequest request)
    {
        var pageNumber = request.Page ?? 0;
        var blogPosts = await _blogReaderDb.BlogPosts
            .OrderByDescending(x => x.CreatedAt)
            .Skip(pageNumber * BlogConstants.PageSize)
            .Take(BlogConstants.PageSize)
            .ToListAsync();

        var blogPostDtos = blogPosts.Select(bp => bp.AsBlogPostDTO(new List<BlogPostSection>())).ToList();

        if (pageNumber == 0 && blogPostDtos.Any()) {
            var squids = new SqidsEncoder<int>(new() { MinLength = 5, Alphabet = BlogConstants.SqidsAlphabet }); 
            var firstId = squids.Decode(blogPostDtos.First().Id).Single();
            var firstBlogPost = await GetBlogPostAsync(firstId);
            blogPostDtos[0] = firstBlogPost.Data;            
        }

        return new BasicResponse<List<BlogPostDTO>>
        {
            Success = true,
            Data = blogPostDtos
        };
    }
}