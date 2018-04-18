using System.Data.Entity;

namespace PersonKartotek
{
    public class KartotekContext : DbContext
    {
        public KartotekContext(): base("name=HandIn2-2")  { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Telephone> Telephones { get; set; }
        public DbSet<MainAddress> MainAddresses { get; set; }
        public DbSet<AlternativeAddress> AlternativeAddresses { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
