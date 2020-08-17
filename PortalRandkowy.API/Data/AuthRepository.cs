using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalRandkowy.API.Models;

namespace PortalRandkowy.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Login(string username, string password)
        {
           var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == username);
           if(user == null)
                return null;
           if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
           return null;

        return user;
        }
        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);
            user.PasswordHash =passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }
        public async Task<bool> UserExists(string name)
        {
            if(await _context.Users.AnyAsync(x => x.UserName == name))
                return true;

            return false;

        }
         private void CreatePasswordHashSalt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
         private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var ComputtedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for(int i =0 ; i < ComputtedHash.Length;i++)   
                {
                    if( ComputtedHash[i] != passwordHash[i])
                    return false;

                }   
                return true;                                    
            }
        }

    }
}