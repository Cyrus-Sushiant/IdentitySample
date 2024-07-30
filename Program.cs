using IdentitySample;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Data Source=.; Initial Catalog=IdentitySampleDb;Integrated Security=true;Application Name=IdentitySample;TrustServerCertificate=True;", dbOptions =>
    {
    });
});

builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddApiEndpoints();

builder.Services.AddAuthorization();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
