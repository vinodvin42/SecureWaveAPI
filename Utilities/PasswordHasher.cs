using CryptSharp.Utility;
using System.Security.Cryptography;
using System.Text;

namespace SecureWaveAPI.Utilities
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = SCrypt.ComputeDerivedKey(
                Encoding.UTF8.GetBytes(password), salt, 16384, 8, 1, null, 32);

            return Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }


        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string[] parts = storedHash.Split(':');
            if (parts.Length != 2) return false;

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHashBytes = Convert.FromBase64String(parts[1]);

            byte[] enteredHashBytes = SCrypt.ComputeDerivedKey(
                Encoding.UTF8.GetBytes(enteredPassword), salt, 16384, 8, 1, null, 32);

            return CryptographicOperations.FixedTimeEquals(enteredHashBytes, storedHashBytes);
        }

        internal static string GenerateRandomToken()
        {
            // Generate a random token
            byte[] tokenData = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tokenData);
            }
            return Convert.ToBase64String(tokenData);
        }
    }
}
