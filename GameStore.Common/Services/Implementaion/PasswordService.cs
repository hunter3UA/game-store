using GameStore.Common.Models;
using GameStore.Common.Services.Abstract;
using System;
using System.Security.Cryptography;

namespace GameStore.BLL.Services.Implementation
{
    public class PasswordService : IPasswordService
    {
        private readonly int _hashLength;
        private readonly int _iterations;
        private readonly int _saltLength;

        public PasswordService()
        {
            _hashLength = 64;
            _iterations = 8;
            _saltLength = 24;
        }

        public SaltedHash CreateSaltedHash(string stringToHash)
        {
            if (stringToHash == null)
                throw new ArgumentNullException("password");

            SaltedHash saltedHash = new SaltedHash() { Salt = CreateToken(_saltLength) };
            using (Rfc2898DeriveBytes hashDriver = new Rfc2898DeriveBytes(stringToHash, saltedHash.Salt, _iterations))
            {
                saltedHash.Hash = hashDriver.GetBytes(_hashLength);
            }

            return saltedHash;
        }

        private bool CheckSaltedHash(string stringToCheck, SaltedHash saltedHash)
        {
            if (stringToCheck == null)
                throw new ArgumentNullException("Password can not be null");
            else if (saltedHash.Hash == null)
                throw new ArgumentNullException("Hash can not be null");
            else if (saltedHash.Salt == null)
                throw new ArgumentNullException("Salt can not be null");

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

        public bool CheckPassword(byte[] passwordHash, byte[] passwordSalt, string password)
        {
            if (passwordHash == null || passwordSalt == null)
                return false;

            SaltedHash saltedHash = new SaltedHash();
            saltedHash.Hash = passwordHash;
            saltedHash.Salt = passwordSalt;
            return CheckSaltedHash(password, saltedHash);
              
        }
    }
}
