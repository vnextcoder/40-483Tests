using System;

namespace tupdatatype {
    class Program {
        static void Main (string[] args) {
            Tuple<int, DateTime> mydata = new Tuple<int, DateTime> (1, DateTime.Now);

            (int, string) somedata = (1, "Hello");

            var vardata = (1, "Hello");
            var vardb = (roll: 1, sex: "m", age : 3, msg: "hello", asof : DateTime.Now);

            var pt1 = (X: 3, Y: 0);
            var pt2 = (X: 3, Y: 4);

            var xCoords = (pt1.X, pt2.X);


            var left = (1,5);
            var right = (1,5);
            Console.WriteLine(left==right);
            
            Console.WriteLine (mydata.ToString ());
            Console.WriteLine (somedata.ToString ());
            Console.WriteLine (vardata.ToString ());

            Console.WriteLine (mydata.GetType ());
            Console.WriteLine (somedata.GetType ());
            Console.WriteLine (vardata.GetType ());




            int x=default;
            string y=default;
            bool z=default;
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);



            Console.WriteLine ("Hello World!");
        }
    }
}