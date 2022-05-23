using System.Collections.Generic;
using System.Threading.Tasks;
using GameStore.BLL.DTO.Publisher;

namespace GameStore.BLL.Services.Abstract
{
    public interface IPublisherService
    {
        Task<PublisherDTO> AddPublisherAsync(AddPublisherDTO addPublisherDTO);

        Task<PublisherDTO> GetPublisherAsync(int id);

        Task<List<PublisherDTO>> GetListOfPublishersAsync();

        Task<PublisherDTO> UpdatePublisherAsync(UpdatePublisherDTO updatePublisherDTO);

        Task<bool> RemovePublisherAsync(int id);
    }
}
