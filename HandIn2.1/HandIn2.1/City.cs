namespace HandIn2._1
{
    class City
    {
        public City(string name, int zipcode)
        {
            CityName = name;
            ZipCode = zipcode;
        }

        public string CityName { get; set; }
        public int ZipCode { get; set; }
    }
}