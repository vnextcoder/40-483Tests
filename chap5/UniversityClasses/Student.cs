using System;
using System.Collections;
using System.Collections.Generic;

namespace UniversityClasses {
    interface IStudent {
        List<string> Courses { get; set; }
        void PrintGrades ();
    }

    public class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Student : Person, IStudent {
        public List<string> Courses { get; set; }

        public void PrintGrades () {
            Console.WriteLine ("Printing all the Student.Grades");
        }
    }

    public class Employee : Person {
        public int EmployeeId { get; set; }
    }

    public class Faculty : Employee {
        private List<string> _CoursesTaught = new List<string> ();
        public List<string> CoursesTaught {
            get { return _CoursesTaught; }
            set { _CoursesTaught = value; }
        }

    }
    public class Staff : Employee {
        public int Shift { get; set; }

    }

    public class TeachingAssistant : Faculty, IStudent {
        public List<string> Courses { get; set; }

        // Implement IStudent.PrintGrades.
        // Print the student's current grades.
        public void PrintGrades () {
            // Do whatever is necessary...
            Console.WriteLine ("TeachingAssistant.PrintGrades");
        }
    }

    // Delegate IStudent to a Student object.
    public class TeachingAssistant2 : Faculty, IStudent {
        // A Student object to handle IStudent.
        private Student MyStudent = new Student ();

        #region IStudent Members

        public List<string> Courses {
            get {
                return MyStudent.Courses;
            }
            set {
                MyStudent.Courses = value;
            }
        }

        public void PrintGrades () {
            MyStudent.PrintGrades ();
        }

        #endregion
    }
    // Implicit implementation.
    public class TeachingAssistant3 : Faculty, IStudent {
        #region IStudent Members

        public List<string> Courses {
            get {
                throw new NotImplementedException ();
            }
            set {
                throw new NotImplementedException ();
            }
        }

        public void PrintGrades () {
            Console.WriteLine ("TeachingAssistant3.PrintGrades");
        }

        #endregion
    }

    // Explicit implementation.
    public class TeachingAssistant4 : Faculty, IStudent {
        #region IStudent Members

        List<string> IStudent.Courses {
            get {
                throw new NotImplementedException ();
            }
            set {
                throw new NotImplementedException ();
            }
        }

        void IStudent.PrintGrades () {
            Console.WriteLine ("TeachingAssistant4.IStudent.PrintGrades");
        }

        #endregion
    }

}