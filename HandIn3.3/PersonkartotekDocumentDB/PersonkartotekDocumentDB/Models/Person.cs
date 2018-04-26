using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using PersonkartotekDocumentDB.Models;

namespace PersonkartotekDocumentDB.Models
{
    public class PersonSimpleDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }

    public class PersonDetailDTO
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Contact Contact { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

}