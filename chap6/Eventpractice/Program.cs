using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using Console = Colorful.Console;
namespace Eventpractice {
    class Program {
        public static BankAccount bank1 = new BankAccount ();
        static void Main (string[] args) {
            //Mutex m = new Mutex ();

            MoneyMarketAccount mmaccount=new MoneyMarketAccount();
            mmaccount.Balance=1000;
            mmaccount.Overdrawn+=AccountLimitErrors;
            mmaccount.Overdrawn+=AccountLimitErrors2;
             //AccountLimitErrors2
            //mmaccount.DebitFee(1200);

            mmaccount.Overdrawn-=AccountLimitErrors;
            
            
            mmaccount.Overdrawn+=AccountLimitErrors2;
            mmaccount.DebitFee(2200);
            Console.WriteLine("hello i am done");
//            DoThreadpractice();

        }

        public static void DoThreadpractice(){
                        bank1.AccountLimitExceeded += AccountLimitErrors;
            bank1.Overdrawn += AccountLimitErrors;
            bank1.Balance = 10000;

            Thread[] threads = new Thread[3];

            threads[0] = new Thread (new ParameterizedThreadStart (AccountOperations));
            //threads[0].Priority = ThreadPriority.Normal;

            threads[1] = new Thread (new ParameterizedThreadStart (AccountOperations));
            //threads[1].Priority = ThreadPriority.AboveNormal;
            threads[2] = new Thread (new ParameterizedThreadStart (AccountOperations));
            //threads[2].Priority = ThreadPriority.Normal;
            List<decimal> allentries1 = new List<decimal> () {-12000 };
            List<decimal> allentries2 = new List<decimal> () { 10000 };
            List<decimal> allentries3 = new List<decimal> () { 1000 };

            var x = from t in threads
            select t.ManagedThreadId;
            Console.WriteLine ($"Starting Bank Balance {bank1.Balance:C}");
            Console.WriteLine ("Created Threads " + string.Join (",", x));

            // allentries.Add(10000,35000,-23000,234000,10000000);
            // allentries.Add(10000,35000,-23000,234000,10000000);

            threads[0].Start (allentries1);
            threads[1].Start (allentries2);
            threads[2].Start (allentries3);

            for (int i = 0; i < 3; i++) {
                threads[i].Join ();
            }

            Console.WriteLine ($"Ending Bank Balance {bank1.Balance:C}");

        }
        public static void AccountLimitErrors (object sender, OverdrawnEventArgs e) {
            Console.WriteLine ($"{e.Text}  Current : {e.CurrentBalance:C}   TXN : {e.TransactionAmount:C}", Color.Red);
        }
        public static void AccountLimitErrors2 (object sender, OverdrawnEventArgs e) {
            Console.WriteLine ($"{e.Text}  in function 2 Current : {e.CurrentBalance:C}   TXN : {e.TransactionAmount:C}", Color.Red);
        }
        public static void AccountOperations (object allentries) {
            List<decimal> journal = allentries as List<decimal>;
            var tId = Thread.CurrentThread.ManagedThreadId;
            // for (int i = 0; i < 10; i++) {
            //     System.Console.WriteLine ($"Thread {tId}  Line number {i}");
            // }

            if (journal != null) {

                //    Console.WriteLine ($"Thread {tId} starting");

                foreach (var i in journal) {

                    lock (bank1) {

                        //    if (tId==4)
                        //        Thread.Sleep(1000);

                        bool b = false;
                        if (i > 0) {
                            //Console.WriteLine ($" {tId} Crediting {i}  ", Color.Azure);
                            b = bank1.Credit (i);
                        } else if (i < 0) {
                            //Console.WriteLine ($" {tId} Debitting {-i}  ", Color.Brown);
                            b = bank1.Debit (-i);
                        } else {
                            Console.WriteLine ("No action needed" + i);
                        }
                        Console.WriteLine ($"{tId} {i:C} Success = {b} Current Balance : {bank1.Balance:C}");
                    }
                }
                Console.WriteLine ($"Current Balance : {bank1.Balance:C}");
                //  Console.WriteLine ($"Thread {tId} ends");
            }

        }
    }

}