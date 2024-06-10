using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace USCarCare.Models
{
    public partial class Model2 : DbContext
    {
        public Model2()
            : base("name=Model21")
        {
        }

        public virtual DbSet<tbl_service> tbl_service { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_service>()
                .Property(e => e.Car_Brand)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_service>()
                .Property(e => e.Car_Model)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_service>()
                .Property(e => e.Car_Type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_service>()
                .Property(e => e.Car_Registration_Number)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_service>()
                .Property(e => e.Service_Type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_service>()
                .Property(e => e.Special_Request)
                .IsUnicode(false);
        }
    }
}
