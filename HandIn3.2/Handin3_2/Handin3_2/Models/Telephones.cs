namespace Handin3_2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Telephones
    {
        [StringLength(128)]
        public string Contact_Email { get; set; }

        public string Number { get; set; }

        public string TeleCompany { get; set; }

        public string Type { get; set; }

        [Key]
        public int TelephoneId { get; set; }

        public virtual Contacts Contacts { get; set; }
    }
}
