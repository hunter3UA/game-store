﻿using GameStore.DAL.Enums;

namespace GameStore.BLL.DTO.User
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Role { get; set; }

        public string PublisherName { get; set; }

    }
}
