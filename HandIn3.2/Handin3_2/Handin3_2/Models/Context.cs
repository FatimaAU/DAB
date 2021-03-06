namespace Handin3_2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<AlternativeAddresses> AlternativeAddresses { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<MainAddresses> MainAddresses { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Telephones> Telephones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>()
                .HasMany(e => e.AlternativeAddresses)
                .WithOptional(e => e.Addresses)
                .HasForeignKey(e => e.Address_AddressId);

            modelBuilder.Entity<Addresses>()
                .HasMany(e => e.MainAddresses)
                .WithOptional(e => e.Addresses)
                .HasForeignKey(e => e.Address_AddressId);

            modelBuilder.Entity<AlternativeAddresses>()
                .HasMany(e => e.Contacts)
                .WithMany(e => e.AlternativeAddresses)
                .Map(m => m.ToTable("ContactAlternativeAddresses").MapLeftKey("AlternativeAddress_AlternativeAddressId").MapRightKey("Contact_Email"));

            modelBuilder.Entity<Cities>()
                .HasMany(e => e.Addresses)
                .WithRequired(e => e.Cities)
                .HasForeignKey(e => e.City_CityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contacts>()
                .HasMany(e => e.People)
                .WithOptional(e => e.Contacts)
                .HasForeignKey(e => e.Contact_Email);

            modelBuilder.Entity<Contacts>()
                .HasMany(e => e.Telephones)
                .WithOptional(e => e.Contacts)
                .HasForeignKey(e => e.Contact_Email);

            modelBuilder.Entity<MainAddresses>()
                .HasMany(e => e.Contacts)
                .WithOptional(e => e.MainAddresses)
                .HasForeignKey(e => e.MainAddress_MainAddressId);
        }
    }
}
