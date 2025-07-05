using System;
using BCrypt.Net;

namespace MoodMind
{
    internal class Hash
    {
        // Method to hash a password using bcrypt
        public static string MakeHash(string password)
        {
            // Generate a salt and hash the password
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
            return hashedPassword;
        }

        public static bool VerifyHash(string enteredPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}
