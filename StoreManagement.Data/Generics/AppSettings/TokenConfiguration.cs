namespace StoreManagement.Data.Generics.AppSettings
{
    public class TokenConfiguration
    {
        public int Creation { get; set; }
        public int Expiration { get; set; }
        public string TokenSecret { get; set; }
    }
}