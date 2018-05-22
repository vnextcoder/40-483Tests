using System;

namespace chap2 {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");
            // check to see how many values in an array are even numbers
            /* int[] numbers = { 5, 24, 36, 19, 45, 60, 78 };
            int evenNums = 0;
            foreach (int num in numbers) {
                Console.WriteLine (num);
                Console.WriteLine (~num);
                Console.WriteLine (num ^ (num));

                if (num % 2 == 0) {
                    evenNums++;
                }
            }
            Console.WriteLine (true | false);
            Console.WriteLine (true & false);
            Console.WriteLine (true ^ false);
            Console.WriteLine (~123);

            for (int i = 0; i < 10; i++) {
                Random rnd = new Random ();
                int num = 0;
                num = rnd.Next (100); // generate a random number between 1 and 100
                // and assign to num
                // if the value in num mod 2 is equal to zero, the operator will return
                // the string even indicating an even number, otherwise it will return
                // the string false
                string type = num % 2 == 0 ? "even" : "odd";
                Console.WriteLine (type + " is for " + num);
            } */
            int [] picked= new int[6];
            for (int select = 0; select < 6; select++) {
                Random rnd = new Random ();
                picked[select] = rnd.Next (49);
            }

            Console.WriteLine ("Your lotto numbers are:");
            for (int j = 0; j < 6; j++) {
                Console.Write (" " + picked[j] + " ");
            }
            Console.WriteLine ();

            Console.WriteLine ("Your lotto numbers with foreach are:");
            foreach (int num2 in picked)
            {
                Console.Write (" " + num2 + " ");
            }
            Console.WriteLine ();
            var mynum=10;
            Console.WriteLine(mynum);
            int mynum2=20;
            Console.WriteLine(mynum2);

        }
    }
}