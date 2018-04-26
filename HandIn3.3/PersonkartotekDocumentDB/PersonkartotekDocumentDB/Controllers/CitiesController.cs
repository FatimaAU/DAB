using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PersonkartotekDocumentDB.Models;

namespace PersonkartotekDocumentDB.Controllers
{
    public class CitiesController : ApiController
    {
        private City[] cities = {
            new City { CityName = "MyCity", ZipCode = "345"},
            new City { CityName = "othercity", ZipCode = "3234"}
        };

        public IEnumerable<City> GetAllCities()
        {
            return cities;
        }

        public IHttpActionResult GetCity(string id)
        {
            var city = cities.FirstOrDefault((p) => p.CityName == id);
            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
    }
}
