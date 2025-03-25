using SecureWaveAPI.Repositories.Interfaces;
using SecureWaveAPI.Repositories;
using SecureWaveAPI.Services.Interfaces;
using SecureWaveAPI.Services;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // ...existing code...
        services.AddScoped<ICredentialRepository, CredentialRepository>();
        services.AddScoped<ICredentialService, CredentialService>();
        // ...existing code...
    }

    // ...existing code...
}