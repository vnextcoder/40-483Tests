using System;

namespace chap3Encapsulated {

    internal class Student {

        private string firstName;
        private char middleInitial;
        private string lastName;
        private int age;
        private string program;
        private double gpa;

        public Student (string first, string last) {
            this.firstName = first;
            this.lastName = last;
        }

        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName {
            get { return lastName; }
            set { lastName = value; }
        }
        public char MiddleInitial {
            get { return middleInitial; }
            set { middleInitial = value; }
        }

        public int Age {
            get { return age; }
            set {
                if (value > 6) {
                    age = value;
                } else {
                    Console.WriteLine ("Student age must be greater than 6");
                }
            }
        }
        public string Program {
            get { return program; }
            set { program = value; }
        }
        public double GPA {
            get { return gpa; }
            set {
                if (value <= 4.0) {
                    gpa = value;
                } else {
                    Console.WriteLine ("GPA cannot be greater than 4.0");
                }
            }
        }
        public void displayDetails () {
            Console.WriteLine (this.FirstName + " " + this.MiddleInitial + " " + this.LastName);
            Console.WriteLine ("Has a GPA of " + this.GPA);
        }
    }

}