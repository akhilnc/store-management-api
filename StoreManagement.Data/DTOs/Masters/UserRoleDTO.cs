using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagement.Data.DTOs.Masters
{
    public class UserRoleDTO
    {
        public long Id { get; set; }
        public string UId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
