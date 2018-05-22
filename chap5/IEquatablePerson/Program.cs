using System;
using System.Collections.Generic;

namespace IEquatablePerson {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            //MultiplePeopls();
            Peopleexercise ();
        }
        static void MultiplePeopls () {
            List<Person> people = new List<Person> ();

            people.Add (new Person () { FirstName = "avinash", LastName = "barnwal" });
            people.Add (new Person () { FirstName = "avinash", LastName = "barnwal" });

            Console.WriteLine (people.Contains (null));

            List<Person2> people2 = new List<Person2> ();

            people2.Add (new Person2 () { FirstName = "avinash", LastName = "barnwal" });
            people2.Add (new Person2 () { FirstName = "avinash", LastName = "barnwal" });

            Console.WriteLine (people2.Contains (null));

            people.Add (null);
            people.Add (null);
            people.Add (null);
            people.Add (null);
            people.Add (null);

            Console.WriteLine (people.Count);

        }
        
        static void Peopleexercise () {
            List<Person> People = new List<Person> ();
            string ans = "Y";
            int i = 1;
            do {
                Console.WriteLine ($"Enter person {i} ");
                Console.Write ("Firstname ");
                string firstname = Console.ReadLine ();

                Console.Write ("Lastname ");
                string lastname = Console.ReadLine ();

                Person p = new Person () { FirstName = firstname, LastName = lastname };
                if (!People.Contains (p)) {
                    People.Add (p);
                    i++;
                }

                Console.Write ("enter more Person? (Y/N) [Default N] ");
                ans = Console.ReadLine ();
            } while (ans.ToUpper() == "Y");

            Console.WriteLine ("entry finished.  Printing all people");
            Array.ForEach<Person> (People.ToArray (), Console.WriteLine);

            //Mapping employee manager
            Console.Write ("enter manager's firstname");
            string managerfirstname = Console.ReadLine ();
            var manager = People.Find (x => x.FirstName == managerfirstname);

            Console.Write ("enter employee's firstname");
            string employeefirstname = Console.ReadLine ();
            var employee = People.Find (x => x.FirstName == employeefirstname);

            employee.Manager = manager;

            //Predicate<Person> p3=new Predicate<Person>():
            Console.WriteLine ("after mapping employee - manager");
            Array.ForEach<Person> (People.ToArray (), Console.WriteLine);

        }
    }
}