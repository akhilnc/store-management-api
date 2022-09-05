using System.Runtime.Serialization;

namespace StoreManagement.Data.Generics.General
{
    public class AppUser
    {
        //[IgnoreDataMember] public UserBase User { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }
        //public Role Role { get; set; }
        //public Permission Permission { get; set; }

        [IgnoreDataMember] public string PasswordHash { get; set; }

        [IgnoreDataMember] public string PasswordSalt { get; set; }

        public string Token { get; set; }
    }
}