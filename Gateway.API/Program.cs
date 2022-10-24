using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

#region  Ocelot middleware
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
#endregion

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapGet("/", async context =>
{
    await context.Response.WriteAsync("Hello World");
}));
app.UseOcelot().Wait();
app.UseAuthorization();
app.Run();

