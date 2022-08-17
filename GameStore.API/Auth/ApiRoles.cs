using GameStore.BLL.Models;

namespace GameStore.API.Auth
{
    public class ApiRoles
    {
        public const string AdministratorRole = Roles.Administrator;
        public const string ManagerRole = AdministratorRole + "," + Roles.Manager;
        public const string PublisherRole = ManagerRole + "," + Roles.Publisher;
        public const string ModeratorRole = ManagerRole + "," + Roles.Moderator;
        public const string UserRole = ManagerRole + "," + Roles.Moderator + "," + Roles.Publisher + "," + Roles.Moderator;
    }
}
