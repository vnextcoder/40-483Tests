using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace chap4 {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");

            double big = -1E40;
            float small = (float) big;

            // if (float.IsInfinity (small)) throw new OverflowException ();

            float zero = 0;

            // float positive = 1 / zero;
            // Console.WriteLine (positive); // Outputs "Infinity"

            float negative = -1 / zero;
            Console.WriteLine (negative); // Outputs "-Infinity"

            Console.WriteLine (int.MaxValue);
            Console.WriteLine (int.MinValue);

            int[] Marks = new int[5] { 10, 23, 44, 93, 29 };

            Array.ForEach (Marks, Console.WriteLine);

            IEnumerable<int> marksQuery =
                from mark in Marks
            where mark > 80
            select mark;

            Console.WriteLine ("now pringing using LINQ");
            foreach (var mark in marksQuery) {
                Console.WriteLine (mark);

            }

            Console.WriteLine ((int) 10.9);

            Console.WriteLine (System.Convert.ToInt32 (10.9));
            Employee e1 = new Employee ("someemployee");
            Person p1 = new Person ("somebody");
            e1 = (Employee) p1;
            p1 = (Person) e1;

            // Declare and initialize an array of Employees.
            Employee[] employees = new Employee[10];
            for (int id = 0; id < employees.Length; id++)
                employees[id] = new Employee (id);
            // Implicit cast to an array of Persons.
            // (An Employee is a type of Person.)
            Person[] persons = employees;

            // (The Persons in the array happen to be Employees.)
            employees = (Employee[]) persons;
            // Use the is operator.
            if (persons is Employee[]) {
                // Treat them as Employees.
                ...
            }

            // Use the as operator.
            employees = persons as Employee[];
            // After this as statement, managers is null.
            Manager[] managers = persons as Manager[];
            // Use the is operator again, this time to see
            // if persons is compatible with Manager[].
            if (persons is Manager[]) {
                // Treat them as Managers.
                //...
            }
            // This cast fails at run time because the array
            // holds Employees not Managers.
            managers = (Manager[]) persons;

            // Explicit cast back to an array of Employees.

        }
    }

    class Employee : Person {
        public new string name;
        public Employee (string pname) : base (pname) {
            this.name = pname;
        }

        
    }
    class Person {

        public string name;
        public Person (string pname) {
            this.name = pname;
        }

    }
}