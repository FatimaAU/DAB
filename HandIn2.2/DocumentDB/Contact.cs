// ADD THIS PART TO YOUR CODE

namespace HandIn2._2
{
    public class Contact
    {
        public string Email { get; set; }
        public MainAddress MainAddress { get; set; }
        public Address[] AlternateAddresses { get; set; }
        public Telephone[] Telephones { get; set; }
    }
}
