using System;
using StoreManagement.Data.EntitiyConfigurations;
using Microsoft.EntityFrameworkCore;
using StoreManagement.Data.Models;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreManagement.Data.DbContexts
{
    public partial class StoreAppContext : DbContext
    {
        public StoreAppContext()
        {
        }

        public StoreAppContext(DbContextOptions<StoreAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminAppLogs> AdminAppLogs { get; set; }
        public virtual DbSet<AdminUserRefreshToken> AdminUserRefreshToken { get; set; }
        public virtual DbSet<MstUser> MstUser { get; set; }
        public virtual DbSet<MstUserRole> MstUserRole { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MstUserConfiguration).Assembly);

        }
    }
}
