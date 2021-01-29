using System;
using System.Globalization;
using System.Collections.Generic;
namespace DbApp
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("1. Add Person Details\n2. Display Person Details\n3. Exit");
                Console.WriteLine("Enter your choice");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Person p = new Person();
                        Console.WriteLine("Enter person id");
                        p.PId = Console.ReadLine();
                        Console.WriteLine("Enter person name");
                        p.PName = Console.ReadLine();
                        Console.WriteLine("Enter date of birth (dd-mm-yyyy)");
                        p.DOB = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        int status = Utility.AddDetails(p);
                        if (status > 0)
                            Console.WriteLine("Insertion successful");
                        else
                            Console.WriteLine("Insertion unsuccessfull! Try again");
                        break;
                    case 2:
                        List<Person> personList = new List<Person>();
                        personList = Utility.DisplayDetails();
                        Console.WriteLine(personList.Count);
                        Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Person ID", "Name", "DOB");
                        foreach (Person person in personList)
                            Console.WriteLine("{0,-20} {1,-20} {2,-20}", person.PId, person.PName, person.DOB.ToString("dd-MM-yyyy"));
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (true);
        }
    }
}
