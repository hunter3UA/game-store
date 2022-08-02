using GameStore.BLL.Models;
using GameStore.DAL.Entities;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPasswordService
    {
        SaltedHash CreateSaltedHash(string stringToHash, int saltLength);

        bool CheckPassword(User loginToCheck, string password);
    }
}
