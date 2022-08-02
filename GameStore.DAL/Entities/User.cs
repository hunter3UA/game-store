using GameStore.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User : BaseEntity
    {
        [Required, MaxLength(150)]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        public string Role { get; set; }

        public IEnumerable<UserRefreshToken> UserRefreshTokens { get; set; }
    }
}
