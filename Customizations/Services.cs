using FastEndpoints;
using hlzn1.APIModels.Blog;
using hlzn1.Blog.Data;
using Microsoft.EntityFrameworkCore;
using hlzn1.Services.Blog;
using hlzn1.DTOs.Blog;

namespace hlzn1.Customizations;

public static class ServiceAdditions
{

    private static void AddThirdPartyServices(this IServiceCollection services)
    {
        services.AddFastEndpoints().AddResponseCaching();
    }

    public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddThirdPartyServices();

        // my services
        services.AddScoped<IReadBlogService, ReadBlogService>();
        services.AddScoped<ICRUDBlogService, CRUDBlogService>();
        //services.AddScoped<ICRUDGenericService<BlogPostCreateDTO, int>, CRUDGenericService<BlogPostCreateDTO, int>>();

        #region SPA Configuration
        services.AddSpaStaticFiles(config =>
        {
            config.RootPath = "client/dist";
        });
        #endregion

        var _env = services.BuildServiceProvider().GetRequiredService<IHostEnvironment>();

        #region Database Configuration
        var connectionString = _env.IsDevelopment() ? configuration.GetConnectionString("PostgresConnString") : Environment.GetEnvironmentVariable("CONNECTION_STRINGH");
        Console.WriteLine($"CONNECTION_STRING = {connectionString}");
        services.AddDbContext<BlogDbContext>(options => {
            options.UseNpgsql(connectionString, config =>
            {
                config.MapEnum<BlogPostSectionContentType>("BlogPostSectionContentType");
            });
        });
        
        #endregion


        #region CORS Configuration
        services.AddCors(options => {
            options.AddPolicy("DevelopmentCorsPolicy", builder => {
                if (_env.IsDevelopment()) {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                } else {
                    builder.WithOrigins("https://production.example.com")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                }
            });
        });
        #endregion
    }

    public static void AddApplicationServices(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
            dbContext.Database.Migrate();
        }

        app.UseResponseCaching().UseFastEndpoints();


        #region SPA Configuration
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        
        app.UseCors("DevelopmentCorsPolicy");
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseSpaStaticFiles();

        app.UseRouting();

        // Review this option
        // app.Use(async (context, next) =>
        // {
        //     var path = context.Request.Path.Value ?? "/";

        //     if (!path.StartsWith("/api") && !path.StartsWith("/health") && !Path.HasExtension(path))
        //     {
        //         context.Request.Path = "/index.html";
        //     }
            
        //     await next();
        // });

        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "client/dist";
        });

        app.Use(async (context, next) =>
        {
            var path = context.Request.Path.Value ?? "/";

            // Allow API, health, and static file requests to pass through
            if (path.StartsWith("/api") || path.StartsWith("/health") || Path.HasExtension(path))
            {
                await next();
            }
            else
            {
                // Redirect all other requests to the SPA
                context.Request.Path = "/index.html";
                await next();
            }
        });

        app.Map("/health", () => Results.Ok("Healthy"));

        #endregion
    }
}