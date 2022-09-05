namespace StoreManagement.Data.Generics.AppSettings
{
    public class PasswordSettings
    {
        public bool IncludeLowercase { get; set; }
        public bool IncludeUppercase { get; set; }
        public bool IncludeNumeric { get; set; }
        public bool IncludeSpecial { get; set; }
        public int Length { get; set; }
    }
}