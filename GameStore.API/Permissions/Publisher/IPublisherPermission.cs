using Microsoft.AspNetCore.Http;

namespace GameStore.API.Permissions.Publisher
{
    public interface IPublisherPermission
    {
        bool CanEditPublisher(HttpContext context, string publisherName);
    }
}
