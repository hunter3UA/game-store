using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStore.DAL.Entities
{
    public class UserRefreshToken : BaseEntity
    {
        public string Token { get; set; }

        [Required]
        public string RefreshToken { get; set; }

        public DateTime CreatedAt { get; set; }
        
        [Required]
        public DateTime ExpirationDate { get; set; }

        [NotMapped]
        public bool IsActive
        {
            get
            {
                return ExpirationDate > DateTime.UtcNow;
            }
        }

        public bool IsInvalidated { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public UserRefreshToken()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
