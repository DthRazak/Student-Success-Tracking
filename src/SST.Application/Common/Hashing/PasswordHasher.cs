using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SST.Application.Common.Interfaces;
using System;

namespace SST.Application.Common.Hashing
{
    public class PasswordHasher: IPasswordHasher
    {
        private readonly string salt;

        public readonly int iterationCount;

        public readonly int bytesNumber;

        public PasswordHasher()
        {
            salt = "oYjmLtIGx7rKEnLmJso2cV5h";
            iterationCount = 10000;
            bytesNumber = 32;
        }

        public string GetPasswordHash(string password)
        {
            var saltBytes = Convert.FromBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: iterationCount,
                numBytesRequested: bytesNumber));

            return hashed;
        }
    }
}
