using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccountManagement_Core.Models
{
    public partial class AM517Context : DbContext
    {
        public virtual DbSet<TblAccountRep> TblAccountRep { get; set; }
        public virtual DbSet<TblClientStatus> TblClientStatus { get; set; }

        // Unable to generate entity type for table 'dbo.tblFooter'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tblDashboard'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=cc-am-dev.cdrlqdez8ehc.us-east-1.rds.amazonaws.com; Initial Catalog=AM517;User ID=sa;Password=primus123;Persist Security Info=True;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAccountRep>(entity =>
            {
                entity.ToTable("tblAccountRep");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountRep)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblClientStatus>(entity =>
            {
                entity.ToTable("tblClientStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ClientStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
