namespace StoreManagement.Infrastructure.Security.Hashing
{
    public interface IHash
    {
        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
        public bool ComparePasswordHash(string password, string storedHash, string storedSalt);
    }
}