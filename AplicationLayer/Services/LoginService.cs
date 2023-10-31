using AplicationLayer.Common;
using AplicationLayer.Interfaces;
using AplicationLayer.Request.Command;
using AplicationLayer.Request.Query;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AplicationLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly JwtSettings _jwtSettings;
        public LoginService(JwtSettings settings)
        {
            _jwtSettings = settings;
        }


        public Result GenerateTokenCommand(RegisterUserCommandRequest user, CancellationToken cancellationToken)
        {
            try
            {
                var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);
                var encryptionKey = Encoding.UTF8.GetBytes(_jwtSettings.EncryptKey);
                var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionKey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
                var claims = GetClaims(user);

                var descriptor = new SecurityTokenDescriptor
                {
                    Issuer = _jwtSettings.Issuer,
                    Audience = _jwtSettings.Audience,
                    NotBefore = DateTime.Now.AddMinutes(_jwtSettings.NotBeforeMinutes),
                    IssuedAt = DateTime.Now,
                    Expires = DateTime.Now.AddHours(_jwtSettings.ExpirationMinutes),
                    SigningCredentials = signingCredentials,
                    Subject = new ClaimsIdentity(claims),
                    EncryptingCredentials = encryptingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(descriptor);
                var jwt = tokenHandler.WriteToken(securityToken);

                return new Result
                {
                    Data = jwt,
                    Error = null,
                    IsSuccess = true,
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new Result
                {
                    Data = null,
                    Error = new string[] { "توکن یافت نشد" },
                    IsSuccess = false,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
            }
        }

        public Result GenerateTokenQuery(LoginUserQueryRequest user, CancellationToken cancellationToken)
        {
            try
            {
                var secretKey = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
                var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature);
                var encryptionKey = Encoding.UTF8.GetBytes(_jwtSettings.EncryptKey);
                var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encryptionKey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
                var claims = GetClaims(user);

                var descriptor = new SecurityTokenDescriptor
                {
                    Issuer = _jwtSettings.Issuer,
                    Audience = _jwtSettings.Audience,
                    NotBefore = DateTime.Now.AddMinutes(_jwtSettings.NotBeforeMinutes),
                    IssuedAt = DateTime.Now,
                    Expires = DateTime.Now.AddHours(_jwtSettings.ExpirationMinutes),
                    SigningCredentials = signingCredentials,
                    Subject = new ClaimsIdentity(claims),
                    EncryptingCredentials = encryptingCredentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(descriptor);
                var jwt = tokenHandler.WriteToken(securityToken);

                return new Result
                {
                    Data = jwt,
                    Error = null,
                    IsSuccess = true,
                    StatusCode = System.Net.HttpStatusCode.OK,
                };
            }
            catch (Exception ex)
            {
                return new Result
                {
                    Data = null,
                    Error = new string[] { "توکن یافت نشد" },
                    IsSuccess = false,
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                };
            }
        }

        private IEnumerable<Claim> GetClaims(RegisterUserCommandRequest user)
        {

            var listClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
            };

            return listClaims;
        }

        private IEnumerable<Claim> GetClaims(LoginUserQueryRequest user)
        {

            var listClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };

            return listClaims;
        }
    }
}
