using GameStore.Common.Models;
using GameStore.Common.Services.Abstract;
using GameStore.DAL.Entities.GameStore;
using GameStore.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace GameStore.DAL.Context.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private readonly IPasswordService _passwordService;

        public UserConfiguration(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                CreateUser("admin@gmail.com", "admin", "Admin", "admin", null),
                CreateUser("user1@gmail.com", "user1", "User", "user1", null),
                CreateUser("manager1@gmail.com", "manager1", "Manager", "manager1", null),
                CreateUser("moderator@gmail.com", "moderator1", "Moderator", "moderator1", null),
                CreateUser("publisher1@gmail.com", "publisher1", "Publisher", "moderator1", "DeepSilver")
                );
        }

        private User CreateUser(string email, string userName, string role, string password, string publisher)
        {
            User newUser = new User();
            SaltedHash saltedHash = _passwordService.CreateSaltedHash(password);

            newUser.Id = Guid.NewGuid().ToString();
            newUser.Email = email;
            newUser.PasswordHash = saltedHash.Hash;
            newUser.PasswordSalt = saltedHash.Salt;
            newUser.PublisherName = publisher;
            newUser.Role = role;
            newUser.UserName = userName;

            return newUser;
        }

    }
}