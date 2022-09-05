using StoreManagement.Data.Generics.AppSettings;
using StoreManagement.Data.Generics.Enum;
using System;

namespace StoreManagement.Data.Generics.General
{
    public class AppTokenSettings<T>
    {
        public T Data { get; set; }
        public TokenType Type { get; set; }
        public ExpirationUnit ExpUnit { get; set; }
        public TokenConfiguration Configuration { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiredAt { get; set; }
        public string Token { get; set; }
        public Guid TokenIdentifier { get; set; }
    }
}