using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreManagement.Data.Models
{
    public partial class MstUser
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string UId { get; set; }
        [Required]
        [StringLength(200)]
        public string UserName { get; set; }
        [Required]
        [StringLength(200)]
        public string EmailId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string ProfileImage { get; set; }
        [Required]
        [StringLength(100)]
        public string MobileNo { get; set; }
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        public bool? IsActive { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        public int RoleId { get; set; }

        public virtual MstUserRole Role { get; set; }
    }
}
