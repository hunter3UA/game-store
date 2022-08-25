using GameStore.API.Extensions;
using GameStore.BLL.DTO.User;
using GameStore.BLL.Models;
using GameStore.BLL.Services.Abstract;
using Microsoft.AspNetCore.Http;

namespace GameStore.API.Permissions.Publisher
{
    public class PublisherPermission : IPublisherPermission
    {
        private readonly IAuthenticationService _authService;

        public PublisherPermission(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public bool CanEditPublisher(HttpContext context, string publisherName)
        {
            UserDTO user = context.GetUser();
            if (user == null)
                return false;

            if (user.Role != Roles.Publisher)
                return true;

            return user.Role == Roles.Publisher && user.PublisherName == publisherName;
        }
    }
}
