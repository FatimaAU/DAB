namespace HandIn2._1
{
    class Telephone
    {
        public Telephone(int number, string info, string teleCompany)
        {
            Number = number;
            Info = info;
            TeleCompany = teleCompany;
        }
        public int Number { get; set; }
        public string Info { get; set; }
        public string TeleCompany { get; set; }
    }
}