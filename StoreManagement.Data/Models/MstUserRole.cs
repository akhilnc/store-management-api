using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreManagement.Data.Models
{
    public partial class MstUserRole
    {
        [Key,ForeignKey("User")]
        public long Id { get; set; }
        [Required]        
        public string UId { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string ShortName { get; set; }
        public bool? IsActive { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        public virtual MstUser User { get; set; }
    }
}
