using Authentication.Backend.Aplications.Services.Users;
using Authentication.Backend.Aplications.Interfaces;
using Authentication.Backend.Infrastructure.Data.Repositories.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Authentication.Backend.Domain.Interfaces.Repository;

var builder = WebApplication.CreateBuilder(args);
var configurationManager = new Authentication.Backend.Utils.ConfigurationManager();
var corsName = "CorsPolicy";


// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddSingleton<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configurationManager.JwtSecretKey))
        };
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Authentication Backend API V1"
    });

    var security = new Dictionary<string, IEnumerable<string>>
    {
        {"Bearer", new string[]{} },
    };

    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization Header",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {new OpenApiSecurityScheme{Reference = new OpenApiReference
        {
            Id = "Bearer",
            Type = ReferenceType.SecurityScheme,
        }}, new List<string>() }
    });
});

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsName, builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(corsName);
app.MapControllers();
app.Run();
