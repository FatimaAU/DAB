namespace HandIn3._2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlternativeAddresses
    {
        [Key]
        public int AlternativeAddressId { get; set; }

        public int? Address_AddressId { get; set; }

        [StringLength(128)]
        public string Contact_Email { get; set; }

        public virtual Addresses Addresses { get; set; }

        public virtual Contacts Contacts { get; set; }
    }
}
