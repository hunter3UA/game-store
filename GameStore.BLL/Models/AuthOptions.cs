using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.BLL.Models
{
    public class AuthOptions
    {
        public const string Issuer = "http://localhost:55845/";

        public const string Audience = "http://localhost:4200";

        private const string Key = "S2V5LU11c3QtQmUtYXQtbGVhc3QtMzItYnl0ZXMtaW4tbGVuZ3RoIQ==";

        public const int LifeTime = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
