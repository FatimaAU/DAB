
// ADD THIS PART TO YOUR CODE

using HandIn2._2;
using Newtonsoft.Json;

namespace HandIn2._2
{

    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
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
