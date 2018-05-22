using System;

namespace inheritance {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            try {
                Console.WriteLine ("Person one");
                Person p = new Person ("john", "Smith");
            } finally {

            }

            try {
                Console.WriteLine ("Person two");
                Person p2 = new Person ("john", "null");
            } finally {

            }
            try {
                Console.WriteLine ("Person three");
                Person p3 = new Person ("john", "a");
            } finally {

            }
            try {
                Console.WriteLine ("Employee 1");
                Person p4 = new Employee ("john", "smith", "Security");
                Console.WriteLine("Person is " + p4.ToString());

            } finally {

            }

        }
    }
}