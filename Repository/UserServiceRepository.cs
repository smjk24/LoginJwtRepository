using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Login.IRepository;
using Login.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Login.Repository
{
    public class UserServiceRepository:IUserServiceRepository
    {
        private readonly ApplicationDbContext _context;
        public UserServiceRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;   
        }
        public async Task<Response> Authenticate(string username, string password)
        {
            var user = await _context.Accounts.FirstOrDefaultAsync(s => s.UserName == username & s.UserPassword == password);
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("your-secret-key-here");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return new Response { IsSuccess=true,Token = tokenString };
            }
            return new Response { IsSuccess = false, Token = "" };
        }
        public async Task<Account> GetUserById(int userid)
        {
            return await _context.Accounts.FirstOrDefaultAsync(s => s.UserId==userid);
        }
    }
}
