using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

builder.Services.AddDbContext<WebApiDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCors", b =>
    {
           b.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .Build();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EnableCors");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();