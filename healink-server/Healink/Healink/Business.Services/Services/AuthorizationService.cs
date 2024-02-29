using AutoMapper;
using Healink.Business.Services.Dto;
using Healink.Data;
using Healink.Entities;
using Healink.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Healink.Business.Services.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        #region properties
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly DataContext _context;
        private readonly JwtSettings _jwtSettings;
        #endregion

        #region constructor
        public AuthorizationService(IMapper mapper, ILogger<UserService> logger, DataContext context, IOptions<JwtSettings> options)
        {
            this._mapper = mapper;
            this._logger = logger;
            this._context = context;
            this._jwtSettings = options.Value;
        }
        #endregion
        #region public functions
        public async Task<Tuple<string, string, long>> GenerateToken(string username, string password, bool isRefresh = false)
        {
            try
            {
                var user = this._context.Users.FirstOrDefault(user => user.Username == username);
                if(user!= null)
                {
                    bool isPasswordValid = PasswordHasher.VerifyPassword(password, user.Password);
                    if (isPasswordValid || password == user.Password)
                    {
                        // Generate token
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var tokenKey = Encoding.UTF8.GetBytes(this._jwtSettings.securityKey);
                        var tokenDesc = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Email, user.Email)
                            }),
                            Expires = DateTime.UtcNow.AddSeconds(60),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                        };
                        var token = tokenHandler.CreateToken(tokenDesc);
                        var finalToken = tokenHandler.WriteToken(token);

                        var refreshToken = await CreateRefreshToken();
                        user.RefreshToken = refreshToken;
                        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(2);
                        if (!isRefresh)
                        {
                            user.LastLogin = DateTime.Now;
                        }
                        await _context.SaveChangesAsync();

                        // Return token and user ID
                        return Tuple.Create(finalToken, refreshToken, user.UserId);
                    }
                    return null;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Tuple<string, string>> Refresh(TokenApiDto tokenApiDto)
        {
            try
            {
                string accessToken = tokenApiDto.AccessToken;
                string refreshToken = tokenApiDto.RefreshToken;

                var principal = GetPrincipalFromExpiredToken(accessToken);
                var username = principal?.Identity?.Name;
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (user != null && ((user.RefreshToken != refreshToken) || (user.RefreshTokenExpiry <= DateTime.Now)))
                {
                    return null;
                }
                var newAccessToken = await GenerateToken(user.Username, user.Password, true);
                var newRefreshToken = await CreateRefreshToken();
                user.RefreshToken = newRefreshToken;
                await _context.SaveChangesAsync();
                return Tuple.Create(newAccessToken.Item1, newRefreshToken);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            var tokenInUser = await _context.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (tokenInUser != null)
            {
                return await CreateRefreshToken();
            }
            return refreshToken;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenKey = Encoding.UTF8.GetBytes(this._jwtSettings.securityKey);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;

            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid Token");
            }
            return principal;
        }
        #endregion

        #region private functions
        #endregion
    }
}
