using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameStore.DAL.Entities
{
    [Index(nameof(UserName), IsUnique = true)]
    public class User
    {
        [Key]
        public string Id { get; set; }

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

        public bool IsDeleted { get; set; }

        public string PublisherName { get; set; }

        public User()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
