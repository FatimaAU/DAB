using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Handin3_2.Models
{
    public class TelephonesDTO
    {
        public TelephonesDTO() { }

        public TelephonesDTO(Telephones telephones)
        {
            ICollection<Telephones> Telephones = new List<Telephones>();
            Telephones.Add(telephones);
        }
        public string TelephoneNumber { get; set; }
        public string TeleCompany { get; set; }
        public string TelephoneType { get; set; }
    }
}