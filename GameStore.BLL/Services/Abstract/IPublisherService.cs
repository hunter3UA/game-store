using GameStore.BLL.DTO.Publisher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPublisherService
    {
        Task<PublisherDTO> AddPublisherAsync(AddPublisherDTO addPublisherDTO);

        Task<PublisherDTO> GetPublisherAsync(int id);

        Task<List<PublisherDTO>> GetListOfPublishersAsync();

        Task<PublisherDTO> UpdatePublisherAsync(AddPublisherDTO updatePublisherDTO);

        Task<bool> RemovePublisherAsync(int id);
    }
}
