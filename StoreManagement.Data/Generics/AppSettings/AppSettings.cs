namespace StoreManagement.Data.Generics.AppSettings
{
    public class AppSettings
    {
        public ConnectionString ConnectionStrings { get; set; }
        public Cryptography Cryptography { get; set; }
        public PasswordSettings PasswordSettings { get; set; }
        public OTPSettings OTPSettings { get; set; }
        public AppTokens Token { get; set; }
        public EmailConfig MailSettings { get; set; }
        public string FileApiUrl { get; set; }
    }
}