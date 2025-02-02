using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Reflection;
using TCDev.ApiGenerator.Data;
using TCDev.ApiGenerator.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiGeneratorServices(builder.Configuration, Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseApiGenerator();
app.UseAutomaticAPIMigrations(true);

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints => {
   endpoints.UseApiGeneratorEndpoints();
   endpoints.MapControllers();
});

app.Run();
