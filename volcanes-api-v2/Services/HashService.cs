using System.Security.Cryptography;
using System.Text;
using volcanes_api_v2.Interfaces;

namespace volcanes_api_v2.Services;

public class HashService : IHashService
{
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
    }

    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(Encoding
                .UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);

        }
    }
}