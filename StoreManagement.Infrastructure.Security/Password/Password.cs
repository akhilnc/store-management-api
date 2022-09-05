using StoreManagement.Data.Generics.AppSettings;
using Microsoft.Extensions.Options;

namespace StoreManagement.Infrastructure.Security.Password
{
    public class Password : IPassword
    {
        private readonly OTPSettings _otpSettings;
        private readonly PasswordSettings _passwordSettings;

        public Password(IOptions<AppSettings> settings)
        {
            _passwordSettings = settings.Value?.PasswordSettings;
            _otpSettings = settings.Value?.OTPSettings;
        }

        public string GenerateRandomPassword(PasswordSettings settings)
        {
            settings = settings == null ? _passwordSettings : settings;
            var pwd = new PasswordGenerator.Password(
                settings.IncludeLowercase,
                settings.IncludeUppercase,
                settings.IncludeNumeric,
                settings.IncludeSpecial,
                settings.Length
            );
            return pwd.Next();
        }

        public string GenerateOTP(int? length)
        {
            length = length == null ? _otpSettings.Length : length;
            var pwd = new PasswordGenerator.Password(length.Value).IncludeNumeric();
            return pwd.Next();
        }
    }
}