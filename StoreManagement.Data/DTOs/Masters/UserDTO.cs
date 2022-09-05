using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagement.Data.DTOs.Masters
{
    public class UserDTO
    {
        public long Id { get; set; }
        public string UId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string  Password { get; set; }
        public string ProfileImage { get; set; }
        public string MobileNo { get; set; }
        public string FullName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public UserRoleDTO Role { get; set; }
    }
}
