using System.Collections.Generic;

namespace HandIn2._1
{
    class Kartotek
    {
        public Kartotek(List<Person> person)
        {
            PersonList = person;
        }

        public List<Person> PersonList = new List<Person>();
    }
}