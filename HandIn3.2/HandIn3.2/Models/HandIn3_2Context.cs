using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HandIn3._2.Models
{
    public class HandIn3_2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public HandIn3_2Context() : base("name=HandIn3-2")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<HandIn3._2.Addresses> Addresses { get; set; }

        public System.Data.Entity.DbSet<HandIn3._2.AlternativeAddresses> AlternativeAddresses { get; set; }

        public System.Data.Entity.DbSet<HandIn3._2.Cities> Cities { get; set; }

        public System.Data.Entity.DbSet<HandIn3._2.Contacts> Contacts { get; set; }

        public System.Data.Entity.DbSet<HandIn3._2.People> People { get; set; }

        public System.Data.Entity.DbSet<HandIn3._2.Telephones> Telephones { get; set; }

        public System.Data.Entity.DbSet<HandIn3._2.MainAddresses> MainAddresses { get; set; }
    }
}
