using FastEndpoints;
using hlzn1.APIModels;
using hlzn1.DTOs.Blog;

namespace hlzn1.Services.Blog;

public class AdminBlogPostCreate : Endpoint<BasicCreateUpdateRequest<BlogPostCreateDTO>, BasicCreateUpdateResponse<BlogPostCreateDTO>>
{
    public required ICRUDBlogService _blogService { get; set; }
    public override void Configure()
    {
        Post("/api/admin/blog/posts");
        AllowAnonymous();
        Description(x => x
            .WithName("Create a new blog post")
            .Produces<BasicResponse<BlogPostDTO>>(200)
            .Produces(400)
            .Produces(500));
    }

    public override async Task HandleAsync(BasicCreateUpdateRequest<BlogPostCreateDTO> req, CancellationToken ct)
    {
        var response = await _blogService.CreateAsync(req);
        if (!response.Success)
        {
            await SendAsync(new BasicCreateUpdateResponse<BlogPostCreateDTO>
            {
                Success = false,
                Message = response.Message
            }, 400, ct);
            return;
        }
        await SendAsync(response, cancellation: ct);
    }
}
