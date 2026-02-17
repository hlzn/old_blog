using hlzn1.APIModels;
using hlzn1.Blog.Data;
using hlzn1.DataModels.Blog;
using hlzn1.DTOs.Blog;

namespace hlzn1.Services.Blog;

public interface ICRUDBlogService
{
    Task<BasicCreateUpdateResponse<BlogPostCreateDTO>> CreateAsync(BasicCreateUpdateRequest<BlogPostCreateDTO> request);
    Task<BasicResponse<BlogPostCreateDTO>> UpdateAsync(BasicCreateUpdateRequest<BlogPostCreateDTO> request);
    Task<BasicResponse<bool>> DeleteAsync(int id);
    Task<BasicResponse<BlogPostCreateDTO>> GetByIdAsync(int id);
    Task<BasicResponse<List<BlogPostCreateDTO>>> GetAllAsync(BasicCollectionRequest request);
}

public class CRUDBlogService : CRUDGenericService<BlogPostCreateDTO, int>, ICRUDBlogService
{
    private readonly BlogDbContext _dbContext;
    private readonly ILogger<CRUDBlogService> _logger;

    public CRUDBlogService(BlogDbContext dbContext, ILogger<CRUDBlogService> logger) : base(dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public override async Task<BasicCreateUpdateResponse<BlogPostCreateDTO>> CreateAsync(BasicCreateUpdateRequest<BlogPostCreateDTO> request)
    {
        try
        {
            var blogPost = new BlogPost
            {
                Title = request.Data.Title,
                Preview = request.Data.Preview,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsPublic = false
            };

            await _dbContext.BlogPosts.AddAsync(blogPost);
            await _dbContext.SaveChangesAsync();

            foreach (var section in request.Data.Sections)
            {
                var blogPostSection = new BlogPostSection
                {
                    BlogPostId = blogPost.Id,
                    ContentType = section.ContentTypeId,
                    Content = section.Content,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Index = section.Index
                };

                await _dbContext.BlogPostSections.AddAsync(blogPostSection);
            }

            await _dbContext.SaveChangesAsync();

            return new BasicCreateUpdateResponse<BlogPostCreateDTO>
            {
                Success = true,
                Data = new BlogPostCreateDTO
                {
                    Id = blogPost.Id,
                    Title = blogPost.Title,
                    Preview = blogPost.Preview,
                    Sections = request.Data.Sections
                }
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating blog post");
            return new BasicCreateUpdateResponse<BlogPostCreateDTO>
            {
                Success = false,
                Message = "Error creating blog post"
            };
        }
    }
}