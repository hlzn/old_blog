using hlzn1.Customizations;

var builder = WebApplication.CreateBuilder(args);
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");
// Add services to the container.
builder.Services.AddCustomServices(builder.Configuration);

var app = builder.Build();

app.AddApplicationServices();

app.Run();
