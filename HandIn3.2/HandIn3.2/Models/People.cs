namespace HandIn3._2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class People
    {
        [Key]
        public int PersonId { get; set; }

        //[StringLength(128)]
        //public string Contact_Email { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public virtual Contacts Contacts { get; set; }
    }
}
