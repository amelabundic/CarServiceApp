using AutoCentarBundic.Data;
using Microsoft.EntityFrameworkCore;

namespace AutoCentarBundic.Services
{
    public class UserService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> Registruj(User user)
        {
            using var context = _contextFactory.CreateDbContext();

            var postoji = await context.Users.AnyAsync(u => u.Email == user.Email);
            if (postoji)
            {
                return false;
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return true;
        }
    }

}
