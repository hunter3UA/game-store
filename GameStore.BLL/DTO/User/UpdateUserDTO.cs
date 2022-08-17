using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.User
{
    public class UpdateUserDTO
    {
        public string Id { get; set; }

        public string Role { get; set; }

        public string UserName { get; set; } 
        
        public string PublisherName { get; set; }
    }
}
