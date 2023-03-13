

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AccountController:BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context  = context;
        }

        [HttpPost("register")]// POST: api/account/register
        public async Task<ActionResult<AppUser>> Register(string username,string password)
        {
            using var hmac= new HMACSHA512(); // using keyword : after using this class then dispose it

            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),//convert the password into byte array
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

    }
}