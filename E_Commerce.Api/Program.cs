using E_Commerce.Api.Configuration;
using E_Commerce.Infrastructure.Extensions;
using E_Commerce.Infrastructure.Security;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


var key = builder.Configuration.GetValue<string>("Jwt:Key");
//Console.WriteLine($"Connection string: {key}"); // Debug purpose only

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceConnection"));
});

builder.Services.ConfigureIdentity();

builder.Services.AddMvc(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});


builder.Services.ConfigureSwaggerAuthentication();

builder.Services.ConfigureJwt(key);
builder.Services.ConfigureEcommerceServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();