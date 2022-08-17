using GameStore.Common.Models;

namespace GameStore.Common.Services.Abstract
{
    public interface IPasswordService
    {
        SaltedHash CreateSaltedHash(string stringToHash);

        bool CheckPassword(byte[] passwordHash,byte[] passwordSalt, string password);
    }
}
