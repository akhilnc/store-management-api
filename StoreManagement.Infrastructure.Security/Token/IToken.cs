using StoreManagement.Data.Generics.Enum;
using StoreManagement.Data.Generics.General;

namespace StoreManagement.Infrastructure.Security.Token
{
    public interface IToken
    {
        TokenOut GenerateToken<T>(AppTokenSettings<T> tokenSettings);
        T ValidateAndDecode<T>(string jwt, TokenType type);
    }
}