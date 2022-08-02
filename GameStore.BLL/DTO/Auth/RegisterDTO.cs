using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Auth
{
    public class RegisterDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        
        [Required,MaxLength(150)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
