using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text;
using WebApplication8.Context;
using WebApplication8.Repositories;
using WebApplication8.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((options) =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Name = "Authorization"
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IProductosRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddDbContext<ShoppingContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("asdasdasdasdasdsadasdXCXCweqeqweqweewqe")
        )
    };
});

builder.Services.AddFluentValidation((options) =>
    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly())
);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();