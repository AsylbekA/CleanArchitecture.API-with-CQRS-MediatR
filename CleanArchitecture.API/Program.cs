using CleanArchitecture.Infrastructure;
using CleanArhcitecture.Application.Features.ProductFetures.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var assembly = AppDomain.CurrentDomain.Load("CleanArhcitecture.Application");
builder.Services.AddMediatR(assembly);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

#region Swagger

builder.Services.AddSwaggerGen(c =>
{
   c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "CQRS.WebApi",
    });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    #region Swagger
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CQRS.WebApi");
    });
    #endregion
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
