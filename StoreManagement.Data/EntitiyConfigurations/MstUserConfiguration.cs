
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagement.Data.Models;

namespace StoreManagement.Data.EntitiyConfigurations
{
   public class MstUserConfiguration : IEntityTypeConfiguration<MstUser>
    {

        public void Configure(EntityTypeBuilder<MstUser> builder)
        {

            builder.Property(x => x.CreatedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(x => x.ModifiedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(a => a.FullName).IsRequired().HasMaxLength(200);
            builder.Property(a => a.UId).IsRequired();
            builder.Property(a => a.EmailId).IsRequired().HasMaxLength(100);
            builder.Property(a => a.MobileNo).IsRequired().HasMaxLength(20);
            builder.Property(a => a.PasswordHash).IsRequired();
            builder.Property(a => a.PasswordSalt).IsRequired();
            builder.Property(a => a.RoleId).IsRequired();
            builder.Property(a => a.Id).IsRequired();

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.HasOne(e => e.Role)
                .WithOne(e => e.User)
                .HasForeignKey<MstUser>(p => p.RoleId);

       
        }
    }
}
