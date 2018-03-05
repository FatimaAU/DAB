using System.Collections.Generic;

namespace HandIn2._1
{
    class Kartotek
    {
        public Kartotek(Person person = null)
        {
            PersonList.Add(person);
        }

        public List<Person> PersonList = new List<Person>();
    }
}