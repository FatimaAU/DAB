namespace HandIn3._2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Addresses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Addresses()
        {
            //AlternativeAddresses = new HashSet<AlternativeAddresses>();
            //MainAddresses = new HashSet<MainAddresses>();
        }

        [Key]
        public int AddressId { get; set; }

        public string StreetName { get; set; }

        public int HouseNumber { get; set; }

        public string Country { get; set; }

        //public int? Cities_CityId { get; set; }

        public string Type { get; set; }

        public virtual Cities Cities { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<AlternativeAddresses> AlternativeAddresses { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<MainAddresses> MainAddresses { get; set; }
    }
}
