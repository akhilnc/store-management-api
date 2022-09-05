using StoreManagement.Data.Generics.AppSettings;

namespace StoreManagement.Infrastructure.Security.Password
{
    public interface IPassword
    {
        public string GenerateRandomPassword(PasswordSettings settings);
        public string GenerateOTP(int? length);
    }
}