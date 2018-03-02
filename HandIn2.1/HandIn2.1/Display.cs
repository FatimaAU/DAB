

namespace HandIn2._1
{
    class Display
    {

        public Display(Person person)
        {
            System.Console.WriteLine("Name: " + person.FirstName + " " + person.MiddleName + " " + person.LastName);
            System.Console.WriteLine("Type: " + person.Type.Types);
            System.Console.WriteLine("Email: " + person.Contact.Email);
            System.Console.WriteLine(person.Contact.Telephone.Info + ":");
            System.Console.WriteLine("\tPhone number: " + person.Contact.Telephone.Number);
            System.Console.WriteLine("\tTelecompany: " + person.Contact.Telephone.TeleCompany + "\n");            
            System.Console.WriteLine(person.Address.Address.Type + ": " + person.Address.Address.StreetName + " " + person.Address.Address.HouseNumber + " " + person.Address.Address.City + " " + person.Address.Address.ZipCode);
        }
    }
}