namespace EntityFW_pj
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PjContext : DbContext
    {
        public PjContext()
            : base("name=PjContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<TableAppointment> TableAppointments { get; set; }
        public virtual DbSet<TablePerson> TablePersons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableAppointment>()
                .Property(e => e.AppointmentDate)
                .IsUnicode(false);

            modelBuilder.Entity<TableAppointment>()
                .Property(e => e.PersonCPR)
                .IsUnicode(false);

            modelBuilder.Entity<TablePerson>()
                .Property(e => e.PersonCPR)
                .IsUnicode(false);

            modelBuilder.Entity<TablePerson>()
                .Property(e => e.PersonName)
                .IsUnicode(false);

            modelBuilder.Entity<TablePerson>()
                .HasMany(e => e.TableAppointments)
                .WithRequired(e => e.TablePerson)
                .WillCascadeOnDelete(false);
        }
    }
}
