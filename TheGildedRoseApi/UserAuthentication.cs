using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TheGildedRoseApi.Models;

namespace TheGildedRoseApi
{
    public class UserAuthentication
    {
        #region Attributes

        private static readonly List<User> RegisteredUsers = UserExtensions.GenerateSampleUsers();

        #endregion


        #region Public Methods

        public static string BuildToken(User user)
        {
            var claims = new[]
            {
                new Claim("UserId", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jwt:256KeyBitKeyForTestingPurposes")); //Key can be anything, string doesn't matter

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("Jwt:Issuer",
                "Jwt:Issuer",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static User Authenticate(UserLogin login)
        {
            // Case sensative
            User user = RegisteredUsers.Where(u => u.UserLogin == login).FirstOrDefault();

            return user;
        }

        #endregion
    }
}