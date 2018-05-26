using System;

namespace chap3Encapsulated {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            Student myStudent = new Student ("Tom", "Thumb");
            myStudent.MiddleInitial = 'R';
            myStudent.Age = 2;
            myStudent.GPA = 3.5;
            myStudent.displayDetails ();

            IPAddress myIP = new IPAddress ();
            // initialize the IP address to all zeros
            for (int i = 0; i < 32; i++) {
                if(i%2==0)
                    myIP[i] = 1;
                    else
                myIP[i] = 0;
            }
            for (int i = 0; i < 32; i++) {
                Console.WriteLine (myIP[i].ToString ());
            }

            //myIP.ToList().ForEach(Console.WriteLine);

            Matrix m=new Matrix();
            m[1,2]=1;
            m[2,3]=3;


            for (int i = 0; i < 4; i++)
            { 
                for (int j = 0; j < 4; j++)
                {
                    Console.WriteLine($" m[{i}][{j}] is {m[i,j]}");
                }
            }

        }
    }

}