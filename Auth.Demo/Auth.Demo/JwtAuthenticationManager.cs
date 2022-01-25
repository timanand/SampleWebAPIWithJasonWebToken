﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// AANA - BEGIN
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
// AANA - END

namespace Auth.Demo
{

    // Class added by AANA
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {

        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        { {"test1", "password1"}, {"test2", "password2"}};

        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }


        public string Authenticate(string username, string password)
        {

            // Checking UserName and Password against local dictionary
            if (!users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            // Create JWT Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(key);

            // Create Security Token Descriptor (pass username, set expiry)
            // (Apart from Algorithm, we are passing a key. Key is nothing but the byte array of the string key that we have expected in
            // constructor which we are going to set in the startup when we add this class to the dependency injection container.)

            // I am keeping the User Id and Password in a read only variable but ideally this would be coming from a data store.


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // will return JWT token back to the caller

        }
    }
}
