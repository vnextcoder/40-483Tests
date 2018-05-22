using System;

namespace UniversityClasses
{
    class Program
    {
        static void Main(string[] args)
        {
//            Console.WriteLine("Hello World!");
            TeachingAssistant ta = new TeachingAssistant();
            IStudent iStudent = new TeachingAssistant4();

            // The following causes a design time error for the
            // TeachingAssistant4 class but not the TeachingAssistant class.
            ta.PrintGrades();

            iStudent.PrintGrades();
            // The following does work.
            IStudent student = ta;
            student.PrintGrades();

        }
    }
}
