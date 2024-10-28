    using _5W2H.Core.Enums;

    namespace _5W2H.Core.Services;

    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role, int id);
        string ComputeSha256Hash(string password);
    }