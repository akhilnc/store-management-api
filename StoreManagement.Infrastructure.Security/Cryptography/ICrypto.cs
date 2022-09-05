namespace StoreManagement.Infrastructure.Security.Cryptography
{
    public interface ICrypto
    {
        public string Encrypt(string input);
        public string Decrypt(string input);
    }
}