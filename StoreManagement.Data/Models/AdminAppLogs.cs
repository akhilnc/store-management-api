using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreManagement.Data.Models
{
    public partial class AdminAppLogs
    {
        public long Id { get; set; }
        public string UId { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string UserUId { get; set; }
        public string LogLevel { get; set; }
        public DateTime IssueAt { get; set; }
    }
}
