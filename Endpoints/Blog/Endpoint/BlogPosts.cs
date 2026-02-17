using FastEndpoints;
using hlzn1.APIModels;
using hlzn1.Constants.Blog;
using hlzn1.DTOs.Blog;
using hlzn1.Services.Blog;
using Sqids;

namespace hlzn1.Endpoints.Blog;

public class GetBlogPostAbout : EndpointWithoutRequest<BasicResponse<BlogPostDTO>>
{
    public required IReadBlogService _blogService { get; set; }
    public override void Configure()
    {
        Get("/api/blog/post/about/{stringid}");
        AllowAnonymous();
        Description(x => x
            .WithName("Get blog post about by ID")
            .Produces<BasicResponse<BlogPostDTO>>(200)
            .Produces(400)
            .Produces(500));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var response = await _blogService.GetBlogPostAboutAsync();
        if (!response.Success)
        {
            await SendAsync(new BasicResponse<BlogPostDTO>
            {
                Success = false,
                Message = BlogConstants.BlogPostNotFound
            }, 400, ct);
            return;
        }
        response.Message = "Blog post fetched successfully.";
        response.Success = true;

        await SendAsync(response, cancellation: ct);
    }
}

public class GetBlogPost : EndpointWithoutRequest<BasicResponse<BlogPostDTO>>
{
    public required IReadBlogService _blogService { get; set; }
    public override void Configure()
    {
        Get("/api/blog/post/{stringid}");
        AllowAnonymous();
        Description(x => x
            .WithName("Get blog post by ID")
            .Produces<BasicResponse<BlogPostDTO>>(200)
            .Produces(400)
            .Produces(500));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var stringId = Route<string>("stringid");
        if (string.IsNullOrEmpty(stringId))
        {
            await SendAsync(new BasicResponse<BlogPostDTO>
            {
                Success = false,
                Message = "Blog post ID is required."
            }, 400, ct);
            return;
        }
        var squids = new SqidsEncoder<int>(new() { MinLength = 5, Alphabet = BlogConstants.SqidsAlphabet });
        var id = squids.Decode(stringId).Single();
        var response = await _blogService.GetBlogPostAsync(id);
        if (!response.Success)
        {
            await SendAsync(new BasicResponse<BlogPostDTO>
            {
                Success = false,
                Message = BlogConstants.BlogPostNotFound
            }, 400, ct);
            return;
        }
        response.Message = "Blog post fetched successfully.";
        response.Success = true;

        await SendAsync(response, cancellation: ct);
    }
}

public class GetBlogPosts : EndpointWithoutRequest<BasicResponse<List<BlogPostDTO>>>
{
    public required IReadBlogService _readBlogService { get; set; }
    public override void Configure()
    {
        Get("/api/blog/posts/{page}");
        AllowAnonymous();
        Description(x => x
            .WithName("Get all blog posts")
            .Produces<BasicResponse<List<BlogPostDTO>>>(200)
            .Produces(400)
            .Produces(500));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        // Extract page number from route if needed (e.g., via Route<T> or other mechanism)
        int page = 0;
        if (Route<int?>("page") is int p)
            page = p;

        var request = new BasicCollectionRequest
        {
            Page = page
        };
        var response = await _readBlogService.GetLatestBlogPostsAsync(request);
        if (!response.Success)
        {
            await SendAsync(new BasicResponse<List<BlogPostDTO>>
            {
                Success = false,
                Message = response.Message
            }, 400, ct);
            return;
        }
        response.Success = true;
        response.Data = response.Data ?? new List<BlogPostDTO>();
        response.MightBeMore = response.Data.Count == BlogConstants.PageSize;
        response.Message = response.MightBeMore ?? false ? BlogConstants.BlogPostsFetched : BlogConstants.LastBlogPostFetched;

        await SendAsync(response, cancellation: ct);
    }
}
