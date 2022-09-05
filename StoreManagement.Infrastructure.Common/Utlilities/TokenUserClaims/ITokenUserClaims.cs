using StoreManagement.Data.Generics.General;

namespace StoreManagement.Infrastructure.Common.Utlilities.TokenUserClaims
{
    public interface ITokenUserClaims
    {
        UserBase GetClaims();
    }
}