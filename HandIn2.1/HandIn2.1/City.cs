namespace HandIn2._1
{
    class City
    {
        public City(string name, string zipcode)
        {
            CityName = name;
            ZipCode = zipcode;
        }

        public string CityName { get; set; }
        public string ZipCode { get; set; }
    }
}