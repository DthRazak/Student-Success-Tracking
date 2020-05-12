using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SST.Application.Common.Interfaces;

namespace SST.Application.Common.Hashing
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly string salt;

        private readonly int iterationCount;

        private readonly int bytesNumber;

        public PasswordHasher()
        {
            salt = "oYjmLtIGx7rKEnLmJso2cV5h";
            iterationCount = 10000;
            bytesNumber = 32;
        }

        public int IterationCount => iterationCount;

        public int BytesNumber => bytesNumber;

        public string GetPasswordHash(string password)
        {
            var saltBytes = Convert.FromBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: IterationCount,
                numBytesRequested: BytesNumber));

            return hashed;
        }
    }
}
