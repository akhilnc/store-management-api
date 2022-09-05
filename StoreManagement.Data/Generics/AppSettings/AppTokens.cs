namespace StoreManagement.Data.Generics.AppSettings
{
    public class AppTokens
    {
        public TokenConfiguration AccessToken { get; set; }
        public TokenConfiguration ResetPasswordToken { get; set; }
        public TokenConfiguration RefreshToken { get; set; }
    }
}