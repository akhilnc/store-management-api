using System;
using System.Linq;
using System.Security.Claims;
using StoreManagement.Data.Generics.General;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace StoreManagement.Infrastructure.Common.Utlilities.TokenUserClaims
{
    public class TokenUserClaims : ITokenUserClaims
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenUserClaims(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserBase GetClaims()
        {
            try
            {
                var userBaseString = _httpContextAccessor.HttpContext.User?.Claims
                    ?.FirstOrDefault(claim => claim.Type == ClaimTypes.UserData)?.Value;
                return JsonConvert.DeserializeObject<UserBase>(userBaseString);
            }
            catch (Exception e)
            {
                return new UserBase();
            }
        }
    }
}