using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace USCarCare.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_user>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.confirm_password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.user_type)
                .IsUnicode(false);
        }
    }
}
