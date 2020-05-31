using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using CheckCenter.Repositories.Interfaces;
using Domain;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;

namespace CheckCenter.Repositories.EF {
    public class EntityFrameworkIdentityRepository : IIdentityRepository {
        
        private readonly IdentityDbContext _context;
        
        public EntityFrameworkIdentityRepository(IdentityDbContext context)
        {
            _context = context;
        }
        
        public User GetUser(string email)
        {
            return _context.Users.Where(u => u.UserEmail.Equals(email)).FirstOr(new User());
        }

        public bool ValidateLogin(User user)
        {
            var dbUser = GetUser(user.UserEmail);
            if (dbUser != null) return dbUser.Password == user.Password;
            return false;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        public string CreateToken(User user) {
            if (user == null) return null;

            var key = Encoding.ASCII.GetBytes("SecretKey-2374-BVADO75ADFV9:859372Y128-tyuw-0131-6573-hvasrg97ad98f");

            // Generate Token for user
            var jwtToken = new JwtSecurityToken("http://localhost:5001/", "http://localhost:5001/", 
                new[] {
                    new Claim("UserEmail", user.UserEmail), new Claim("Password", user.Password)
                }, new DateTimeOffset(DateTime.Now).DateTime,
                new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,

                // Using HS256 Algorithm to encrypt Token  
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}
