using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erdinc_MCTG.DB
{
    public class PwHasher
    {
        public static string HashPassword(string password)
        {
            // Hash das Passwort mit BCrypt, Standard Work Factor = 10
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            // Vergleiche das eingegebene Passwort mit dem gehashten Passwort
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }
}

