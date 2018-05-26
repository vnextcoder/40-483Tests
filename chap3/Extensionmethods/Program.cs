using System;
using System.Runtime.InteropServices;
namespace chap3 {
    public static class MyExtendedMethods {
        public static int square (this int num) {
            int result = 0;
            result = num * num;
            return result;
        }
        public static int lenn(this string stringVar){
            int length=0;
            length=stringVar.Length;
            return length;
        }
    }
    class Program {

        static void Main (string[] args) {
            //   exer2 ();
            //practice1 ();

            //    practiceenum ();

            classexample ();
            //ExtensionMethods ();

        }
        static void ExtensionMethods () {
            int i = 1023;;
            string abc ="hello india";
            Console.WriteLine ($"Square of {i} is {i.square()}");
            Console.WriteLine ($"Length of {abc} is {abc.lenn()}");
            

            positionalParams(width:10,length:20, pi:3);
            positionalParams(12,width:22,length:23);


        }

        static void positionalParams(int pi, int length, int width){

            Console.WriteLine($"length is {length}");
            Console.WriteLine($"width is {width}");
            Console.WriteLine($"pi is {pi}");
        }

        public class Student2 {
            public static int StudentCount;
            public string firstName;
            public string lastName;
            public string grade;
            public string FirstName{
                get{return firstName;}
                set {firstName=value;}


            }
            public string concatenateName () {
                string fullName = this.firstName + " " + this.lastName;
                return fullName;
            }
            public void displayName () {
                string name = concatenateName ();
                Console.WriteLine (name);
            }
            public Student2 (string first, string last, string grade) {
                this.firstName = first;
                this.lastName = last;
                this.grade = grade;
            }

        }
        static void classexample () {
            Student2 firstStudent = new Student2 ("John", "Smith", "six");
            Student2.StudentCount++;
            Student2 secondStudent = new Student2 ("Tom", "Thumb", "two");
            Student2.StudentCount++;

            Console.WriteLine (firstStudent.firstName);
            Console.WriteLine (secondStudent.firstName);
            Console.WriteLine (Student2.StudentCount);

            firstStudent.FirstName="Hello";
            secondStudent.FirstName="Challo";

            firstStudent.displayName ();
            secondStudent.displayName ();
        }

        enum Months {
            Jan = 100, Feb, Mar, Apr, May, Jun, Jul, Aug, Sept,
            Oct, Nov, Dec
            };

            static void practiceenum () {

            string name = Enum.GetName (typeof (Months), 107);
            Console.WriteLine ("The 8th month in the enum is " + name);
            Console.WriteLine ("The underlying values of the Months enum:");
            foreach (int values in Enum.GetValues (typeof (Months))) {
            Console.WriteLine (values);
            }

        }

        struct Book {
            public string title;
            public string category;
            public string author;
            public int numPages;
            public int currentPage;
            public double Isbn;
            public string coverstyle;
            public Book (string title, string category, string author, int numPages, int currentPage, double isbn, string cover) {

                this.title = title;
                this.category = category;
                this.author = author;
                this.numPages = numPages;
                this.currentPage = currentPage;
                this.Isbn = isbn;
                this.coverstyle = cover;
            }

            public int nextPage () {
                if (currentPage < numPages) {
                    currentPage++;
                    Console.WriteLine ("Current page is now: " + this.currentPage);
                } else {

                    Console.WriteLine ("At end of BOok already!");
                }

                return currentPage;

            }
            public int prevPage () {
                if (currentPage > 1) {
                    currentPage--;
                    Console.WriteLine ("Current page is now: " + this.currentPage);
                } else {
                    Console.WriteLine ("At the beginning of the book.");
                }

                return currentPage;

            }

        }
        struct Student {
            public string firstName;
            public string lastname;
            public char initial;
            public double score1;
            public double score2;
            public double score3;
            public double score4;
            public double score5;
            public double average;

            private string hasWhat;
            // Student (string pname, string pfathername) {
            //     name = pname;
            //     fathername = pfathername;
            // }

            public Student (string has) {
                hasWhat = has;
                firstName = "hello";
                lastname = "hello";
                initial = 'C';
                score1 = score2 = score3 = score4 = score5 = 100;
                average = (score1 + score2 + score3 + score4 + score5) / 5;

            }

            public void takeit (string newHas) {
                hasWhat = newHas;
            }

            public string getit () {
                return hasWhat;
            }
        }
        static void practice1 () {
            Book myBook = new Book ("MCSD Certification Toolkit (Exam 70-483)",
                "Certification", "Covaci, Tiberiu", 648, 1, 81118612095, "Soft Cover");
            Console.WriteLine (myBook.title);
            Console.WriteLine (myBook.category);
            Console.WriteLine (myBook.author);
            Console.WriteLine (myBook.numPages);
            Console.WriteLine (myBook.currentPage);
            Console.WriteLine (myBook.Isbn);
            Console.WriteLine (myBook.coverstyle);
            for (int i = 0; i < 10; i++) {
                myBook.nextPage ();
            }

            myBook.prevPage ();
        }
        static void exer2 () {
            // declare some numeric data types
            int myInt;
            double myDouble;
            byte myByte;
            char myChar;
            decimal myDecimal;
            float myFloat;
            long myLong;
            short myShort;
            bool myBool;
            // assign values to these types and then
            // print them out to the console window
            // also use the sizeOf operator to determine
            // the number of bytes taken up be each type
            myInt = 5000;
            Console.WriteLine ("Integer");
            Console.WriteLine (myInt);
            Console.WriteLine (myInt.GetType ());
            Console.WriteLine (sizeof (int));
            Console.WriteLine ();
            myDouble = 5000.0;
            Console.WriteLine ("Double");
            Console.WriteLine (myDouble);
            Console.WriteLine (myDouble.GetType ());
            Console.WriteLine (sizeof (double));
            Console.WriteLine ();
            myByte = 254;
            Console.WriteLine ("Byte");
            Console.WriteLine (myByte);
            Console.WriteLine (myByte.GetType ());
            Console.WriteLine (sizeof (byte));
            Console.WriteLine ();
            myChar = 'r';
            Console.WriteLine ("Char");
            Console.WriteLine (myChar);
            Console.WriteLine (myChar.GetType ());
            Console.WriteLine (sizeof (char));
            Console.WriteLine ();
            myDecimal = 20987.89756M;
            Console.WriteLine ("Decimal");
            Console.WriteLine (myDecimal);
            Console.WriteLine (myDecimal.GetType ());
            Console.WriteLine (sizeof (decimal));
            Console.WriteLine ();
            myFloat = 254.09F;
            Console.WriteLine ("Float");
            Console.WriteLine (myFloat);
            Console.WriteLine (myFloat.GetType ());
            Console.WriteLine (sizeof (float));
            Console.WriteLine ();
            myLong = 2544567538754;
            Console.WriteLine ("Long");
            Console.WriteLine (myLong);
            Console.WriteLine (myLong.GetType ());
            Console.WriteLine (sizeof (long));
            Console.WriteLine ();
            myShort = 3276;
            Console.WriteLine ("Short");
            Console.WriteLine (myShort);
            Console.WriteLine (myShort.GetType ());
            Console.WriteLine (sizeof (short));
            Console.WriteLine ();
            myBool = true;
            Console.WriteLine ("Boolean");
            Console.WriteLine (myBool);
            Console.WriteLine (myBool.GetType ());
            Console.WriteLine (sizeof (Boolean));
            Student s1 = new Student ("Box");
            Console.WriteLine ("size of student is " + Marshal.SizeOf (s1));

            s1.takeit ("rectangle");

            Console.WriteLine ("Got it " + s1.getit ());
            Console.WriteLine ();

        }
        static void exer1 () {
            Console.WriteLine ("Hello World!");

            uint x = UInt32.MaxValue;
            Console.WriteLine ("Hello i am " + x);
            Console.WriteLine ("Hello i am " + (x + 2));

            // Student s1;
            // Console.WriteLine (s1);
            // create a variable to hold a value type using the alias form
            // but don't assign a variable
            //int myInt;
            int myNewInt = new int ();
            // create a variable to hold a .NET value type
            // this type is the .NET version of the alias form int
            // note the use of the keyword new, we are creating an object from
            // the System.Int32 class
            System.Int32 myInt32 = new System.Int32 ();
            // you will need to comment out this first Console.WriteLine statement
            // as Visual Studio will generate an error about using an unassigned
            // variable. This is to prevent using a value that was stored in the
            // memory location prior to the creation of this variable
            //Console.WriteLine(myInt);
            // print out the default value assigned to an int variable
            // that had no value assigned previously
            Console.WriteLine (myNewInt);
            // this statement will work fine and will print out the default value for
            // this type, which in this case is 0
            Console.WriteLine (myInt32);
        }
    }
}