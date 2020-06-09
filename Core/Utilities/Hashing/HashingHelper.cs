using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Hashing
{
    /// <summary>
    /// CreatePasswordHash metodu parametre olarak verilen password değerine göre passwordSalt ve passwordHash anahtarlarını oluşturmaktadır.
    /// 
    /// VerifyPasswordHash methodu parametre olarak verilen password ve passwordSalt değerleri ile kendi oluşturduğu computedHash değerinin parametre olarak verilen passwordHash değerine eşit olup olmadığını control etmektedir.
    /// </summary>
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
