namespace SecureWaveAPI.Services.Interfaces
{
    public interface ICurrentUserService
    {
        Guid GetCurrentUserId(); // Get the current user's ID
        string GetCurrentUsername(); // Get the current user's username
        string GetCurrentUserRole(); // Get the current user's role
    }
}
