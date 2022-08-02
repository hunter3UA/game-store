using GameStore.BLL.Models;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Cryptography;

namespace GameStore.BLL.Services.Implementation
{
    public class PasswordService : IPasswordService
    {
        private readonly int _hashLength;
        private readonly int _iterations;

        public PasswordService(IConfiguration configuration)
        {
            _hashLength = configuration.GetValue<int>("Password:HashLength");
            _iterations = configuration.GetValue<int>("Password:HashIterations");
        }

        public SaltedHash CreateSaltedHash(string stringToHash, int saltLength)
        {
            if (stringToHash == null)
                throw new ArgumentNullException("password");
            else if (saltLength <= 0)
                throw new ArgumentOutOfRangeException("saltLenght", "number must be positive");

            SaltedHash saltedHash = new SaltedHash() { Salt = CreateToken(saltLength)};
            using (Rfc2898DeriveBytes hashDriver = new Rfc2898DeriveBytes(stringToHash, saltedHash.Salt, _iterations))
            {
                saltedHash.Hash = hashDriver.GetBytes(_hashLength);
            }

            return saltedHash;
        }

        public bool CheckPassword(User loginToCheck, string password)
        {
            if (loginToCheck != null)
            {
                SaltedHash saltedHash = new SaltedHash();
                saltedHash.Hash = loginToCheck.PasswordHash;
                saltedHash.Salt = loginToCheck.PasswordSalt;
                if (CheckSaltedHash(password, saltedHash))
                    return true;
            }

            return false;
        }

        private bool CheckSaltedHash(string stringToCheck, SaltedHash saltedHash)
        {
            if (stringToCheck == null)
                throw new ArgumentNullException("password");
            else if (saltedHash.Hash == null)
                throw new ArgumentNullException("hash");
            else if (saltedHash.Salt == null)
                throw new ArgumentNullException("Salt");

            byte[] hashGenerated = null;
            using (Rfc2898DeriveBytes hashDriver = new Rfc2898DeriveBytes(stringToCheck, saltedHash.Salt, _iterations))
            {
                hashGenerated = hashDriver.GetBytes(_hashLength);
            }

            return ByteArraysEqual(hashGenerated, saltedHash.Hash);
        }

        private byte[] CreateToken(int TokenLength)
        {
            if (TokenLength <= 0)
                throw new ArgumentOutOfRangeException("TokenLength", "number must be positive");

            RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
            var salt = new byte[TokenLength];
            rngCsp.GetNonZeroBytes(salt);
            return salt;
        }

        private bool ByteArraysEqual(byte[] buff1, byte[] buff2)
        {
            if (buff1.Length != buff2.Length)
                return false;

            for (int i = 0; i < buff2.Length; i++)
            {
                if (buff1[i] != buff2[i])
                    return false;
            }

            return true;
        }
    }
}
