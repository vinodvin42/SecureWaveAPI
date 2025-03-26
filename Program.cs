// Program.cs

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SecureWave.Data;
using SecureWave.Services;
using SecureWaveAPI.Repositories.Interfaces;
using SecureWaveAPI.Repositories;
using SecureWaveAPI.Services.Interfaces;
using SecureWaveAPI.Services;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Register DbContext
        builder.Services.AddDbContext<SecureWaveDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add services to the container.
        // Register IHttpContextAccessor
        builder.Services.AddHttpContextAccessor();

        // Register IEmailService with required parameters
        var smtpSettings = builder.Configuration.GetSection("Smtp");
        builder.Services.AddScoped<IEmailService>(provider => new EmailService(
            smtpSettings["Host"],
            int.Parse(smtpSettings["Port"]),
            smtpSettings["FromEmail"],
            smtpSettings["User"],
            smtpSettings["Pass"]
        ));

        // Register AuthService
        builder.Services.AddScoped<AuthService>();

        // Register ICurrentUserService
        builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

        // Register Services
        builder.Services.AddScoped<IUserService, UserService>();
        // Register Repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        // Register Services
        builder.Services.AddScoped<IRoleService, RoleService>();
        // Register Repositories
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        // Register Services
        builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
        // Register Repositories
        builder.Services.AddScoped<IResourceService, ResourceService>();
        // Register repositories
        builder.Services.AddScoped<ICredentialRepository, CredentialRepository>();
        // Register Services
        builder.Services.AddScoped<ICredentialService, CredentialService>();
        //Register RequestAccessRepository
        builder.Services.AddScoped<IAccessRequestRepository, AccessRequestRepository>();
        //Register RequestAccessService
        builder.Services.AddScoped<IAccessRequestService, AccessRequestService>();
        

        // Add JWT Authentication
        var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SecretKey"]);
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

        // Configure CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", policyBuilder =>
            {
                policyBuilder
                    .WithOrigins("http://localhost:3000", "https://localhost:3000") // Frontend origin(s)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        // Add Controllers
        builder.Services.AddControllers();

        // Add Swagger for API documentation (optional but helpful)
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        // Apply CORS Policy before Authentication & Authorization
        app.UseCors("CorsPolicy");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
