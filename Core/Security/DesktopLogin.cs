using System;
using System.Security.Cryptography;

namespace Core.Security
{
    public static class DesktopLogin
    {
        public static string HashPassword(string password)
        {
            const int saltSize = 128;
            const int pbkdf2IterCount = 1000;
            const int pbkdf2SubkeyLength = 256;

            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            // Produce a version 0 (see comment above) password hash.
            byte[] salt;
            byte[] subkey;
           

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltSize, pbkdf2IterCount))
            {
                salt = deriveBytes.Salt;
                subkey = deriveBytes.GetBytes(pbkdf2SubkeyLength);
            }

            byte[] outputBytes = new byte[1 + saltSize + pbkdf2SubkeyLength];
            Buffer.BlockCopy(salt, 0, outputBytes, 1, saltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + saltSize, pbkdf2SubkeyLength);
            return Convert.ToBase64String(outputBytes);
        }

        public static bool ByteArraysEqual(byte[] a1, byte[] a2)
        {
            if (a1 == a2)
            {
                return true;
            }
            if ((a1 != null) && (a2 != null))
            {
                if (a1.Length != a2.Length)
                {
                    return false;
                }
                for (int i = 0; i < a1.Length; i++)
                {
                    if (a1[i] != a2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool VerifyHashedPassword(string hashedPassword, string password)
        {
            const int saltSize = 16;
            const int pbkdf2IterCount = 1000;
            const int pbkdf2SubkeyLength = 32;


            if (hashedPassword == null)
            {
                throw new ArgumentNullException("hashedPassword");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);

            // Verify a version 0 (see comment above) password hash.

            if (hashedPasswordBytes.Length != (1 + saltSize + pbkdf2SubkeyLength) || hashedPasswordBytes[0] != 0x00)
            {
                // Wrong length or version header.
                return false;
            }

            byte[] salt = new byte[saltSize];
            Buffer.BlockCopy(hashedPasswordBytes, 1, salt, 0, saltSize);
            byte[] storedSubkey = new byte[pbkdf2SubkeyLength];
            Buffer.BlockCopy(hashedPasswordBytes, 1 + saltSize, storedSubkey, 0, pbkdf2SubkeyLength);

            byte[] generatedSubkey;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, pbkdf2IterCount))
            {
                generatedSubkey = deriveBytes.GetBytes(pbkdf2SubkeyLength);
            }
            return ByteArraysEqual(storedSubkey, generatedSubkey);
        }
    }
}
