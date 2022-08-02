using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Auth
{
    public class AuthRequestDTO
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
