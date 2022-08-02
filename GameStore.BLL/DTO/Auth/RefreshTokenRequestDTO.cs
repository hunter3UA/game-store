using System.ComponentModel.DataAnnotations;

namespace GameStore.BLL.DTO.Auth
{
    public class RefreshTokenRequestDTO
    {
        [Required]
        public string ExpiredAccessToken { get; set; }

        [Required]
        public string RefreshToken { get; set; }
    }
}
