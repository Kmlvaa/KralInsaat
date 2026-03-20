using AutoMapper;
using KralInsaat.Common.DTOs.Auth;
using KralInsaat.Common.Exceptions;
using KralInsaat.Common.Options;
using KralInsaat.Db;
using KralInsaat.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KralInsaat.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IOptions<JwtOptions> _jwtOptions;

        public AuthService(UserManager<AppUser> userManager, AppDbContext appDbContext, IMapper mapper, IOptions<JwtOptions> options)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _mapper = mapper;
            _jwtOptions = options;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email) ?? throw new NotFoundException($"User with the email address {model.Email} is not found");

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
                throw new BadRequestException("Password is incorrect");

            var accessToken = GenerateJwtToken(user);

            var dto = new LoginResponseDTO 
            { 
                AccessToken = accessToken.Result
            };

            return dto;
        }

        public async Task RegisterAsync(RegisterRequestDTO model)
        {
            var userExists = await _userManager.Users.AnyAsync(x => x.Email.ToLower() == model.Email.ToLower());
            if (userExists) throw new BadRequestException("User already registered.");

            var user = _mapper.Map<AppUser>(model);
            user.CreatedAt = DateTime.UtcNow;
            user.UserName = model.Email;

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) throw new BadRequestException(string.Join("; ", result.Errors.Select(e => e.Description)));

            await _userManager.UpdateAsync(user);
            await _appDbContext.SaveChangesAsync();
        }


        #region Token Generator
        private async Task<string> GenerateJwtToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("sub", user.UserId.ToString()),
                new Claim("jti", Guid.NewGuid().ToString()),
                new Claim("SecurityStamp", user.SecurityStamp ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var accessToken = new JwtSecurityToken(
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtOptions.Value.AccessTokenDurationMinutes),
                signingCredentials: creds
            );

            string accessTokenString = new JwtSecurityTokenHandler().WriteToken(accessToken);

            return accessTokenString;
        }

        #endregion
    }
}
