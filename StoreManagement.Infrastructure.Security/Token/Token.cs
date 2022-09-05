using StoreManagement.Data.Generics.AppSettings;
using StoreManagement.Data.Generics.Enum;
using StoreManagement.Data.Generics.General;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StoreManagement.Infrastructure.Security.Token
{
    public class Token : IToken
    {
        private readonly AppTokens _tokenConfig;

        public Token(IOptions<AppSettings> appSettings)
        {
            _tokenConfig = appSettings.Value?.Token;
        }

        public TokenOut GenerateToken<T>(AppTokenSettings<T> tokenSettings)
        {

            tokenSettings.Configuration = GetTokenConfig(tokenSettings.Type);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(tokenSettings.Configuration.TokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(tokenSettings.Data))
                }),
                Expires = GetExpiryTime(tokenSettings.Configuration.Expiration, tokenSettings.ExpUnit),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new TokenOut
            {
                Token = tokenHandler.WriteToken(token),
                TokenExpiry = tokenDescriptor.Expires.Value
            };
        }

        public T ValidateAndDecode<T>(string jwt, TokenType type)
        {
            try
            {
                var config = GetTokenConfig(type);
                var validationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.TokenSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };

                var handler = new JwtSecurityTokenHandler();

                var principal = handler.ValidateToken(jwt, validationParameters, out var validToken);
                var validJwt = validToken as JwtSecurityToken;

                return JsonConvert.DeserializeObject<T>(principal.FindFirstValue(ClaimTypes.UserData));
            }
            catch (Exception ex)
            {
                return default;
            }
        }

        #region Token

        private TokenConfiguration GetTokenConfig(TokenType type)
        {
            var config = new TokenConfiguration();
            switch (type)
            {
                case TokenType.AccessToken:
                    config = _tokenConfig.AccessToken;
                    break;
                case TokenType.RefreshToken:
                    config = _tokenConfig.RefreshToken;
                    break;
                case TokenType.ResetPasswordToken:
                    config = _tokenConfig.ResetPasswordToken;
                    break;
            }
            return config;
        }

        private DateTime GetExpiryTime(int expiration, ExpirationUnit unit)
        {
            var expDate = DateTime.UtcNow;
            switch (unit)
            {
                case ExpirationUnit.Minute:
                    expDate = DateTime.UtcNow.AddMinutes(expiration);
                    break;
                case ExpirationUnit.Hour:
                    expDate = DateTime.UtcNow.AddHours(expiration);
                    break;
                case ExpirationUnit.Day:
                    expDate = DateTime.UtcNow.AddDays(expiration);
                    break;
            }
            return expDate;
        }

        #endregion
    }
}