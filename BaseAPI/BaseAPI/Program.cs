using Microsoft.OpenApi.Models;
using BaseAPI.Business.Interface.Security;
using BaseAPI.Business.Security;
using BaseAPI.Business.Authentication;
using BaseAPI.Business.Interface.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Registra las implementaciones de tus interfaces y clases de negocio aqu�
builder.Services.AddTransient<ICryptographyBusiness,CryptographyBusiness>();
builder.Services.AddTransient<ILoginBusiness, LoginBusiness>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Mi API Segura",
            Version = "v1",
            Description = "API para Encriptaci�n de respuestas",
        });
        c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Inserta el token JWT en este formato: Bearer {tokemn}",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement{
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                    Type= ReferenceType.SecurityScheme,
                    Id= "Bearer",
                    },
                },
                Array.Empty<string>()
            },
        });
    }
);

// Configuración de la autenticación y autorización
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "22d1c2e80fbcec3a7aff5d3436709e94",
            ValidAudience = "065399b83e51bac411059d12ec42a2d4",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("a9bb8813-1b25-5649-a9c3-1e8e6dfd550b")),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API Segura v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();