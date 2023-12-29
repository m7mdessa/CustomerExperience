using CustomerExperience.Core.Application.DTO;
using CustomerExperience.Core.Domain.RoleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CustomerExperience.Core.Infra.Repositories
{
    public class RoleRepository :IRoleRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly JwtSettings _jwtSettings;

        public RoleRepository(AppDbContext dbContext, IOptions<JwtSettings> jwtSettings)
        {
            _dbContext = dbContext;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task UpdateAsync(Role role)
        {
            _dbContext.Roles.Update(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Role> AddAsync(Role role)
        {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
            return role;
        }
        public async Task<Role> GetByIdAsync(int id)
        {
            return await _dbContext.Roles.Include(r=>r.Users).FirstOrDefaultAsync(d => d.Id == id);
        }

      

        public string Login(string username, string password)
        {
            var login = _dbContext.Roles.Include(d => d.Users)
                .Where(r => r.Users.Any(u => u.UserName == username && u.Password == password))
            .Select(r => new
            {
                Role = r,
                User = r.Users.FirstOrDefault(u => u.UserName == username)

            })
            .FirstOrDefault();

            if (login != null)
            {


                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

                var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var user = login.User;

                var claims = new List<Claim>
                {
                new Claim("RoleId", user.RoleId.ToString()),
                new Claim("CustomerId", user.CustomerId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iss,_jwtSettings.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience)
                };

                var jwtSecurityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signinCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return token;
            }
            else
            {
                return null;
            }
        }

    }
}
