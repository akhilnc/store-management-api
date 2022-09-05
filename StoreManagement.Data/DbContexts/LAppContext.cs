using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StoreManagement.Data.Models;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreManagement.Data.DbContexts
{
    public partial class LAppContext : DbContext
    {
        public LAppContext()
        {
        }

        public LAppContext(DbContextOptions<LAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminAppLogs> AdminAppLogs { get; set; }
        public virtual DbSet<AdminUserRefreshToken> AdminUserRefreshToken { get; set; }
        public virtual DbSet<MstUser> MstUser { get; set; }
        public virtual DbSet<MstUserRole> MstUserRole { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstUserRole>().HasData(
                new MstUserRole
                {
                    Id=1,
                    UId=Guid.NewGuid().ToString(),
                    CreatedBy="test",
                    CreatedOn=DateTime.Now,
                    IsActive=true,
                    ModifiedBy="asda",
                    ModifiedOn=DateTime.Now,
                    Name="admin",
                    ShortName="Ad"
                }
                );
        }
    }
}
