namespace GameStore.BLL.DTO.Auth
{
    public class AuthResponseDTO
    {
        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public bool IsSuccess { get; set; }

        public string Reason { get; set; }
    }
}
