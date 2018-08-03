using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqtoOjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ms_softwares =
            {
                "VS2010_IDE",
                "SS2010_IDE",
                "SP2010_Portal",
                "VSTS2010_IDE",
                "VS2008_IDE",
                "SS2008_IDE",
                "BTS2010_EIA",
                "TFS2010_CI"
            };
            string[] java_softwares =
            {
                "Eclipse_IDE",
                "Oracle_DB",
                "WebSphere_EIA",
                "NetBeans_IDE"
            };
            //Requirement : Display all the Softwares whose length is greater than 6 chars
            //LINQ query body must end with Select clause or Group by clause.
            
            //IEnumerable<string> results = from s in softwares
            //                            where s.Length > 6
            //                            select s;

            //Display the software names alongwith the length of each software
            //var results = from s in ms_softwares
            //              select new { Name = s, Length = s.Length };

            #region Requirement 3
            //Display microsoft and java IDE softwares
            //var results = from ms in ms_softwares
            //              from js in java_softwares
            //              where ms.EndsWith("IDE") & js.EndsWith("IDE")
            //              select new { Microsoft = ms, Java = js };


            //var results = from ms in ms_softwares
            //              from js in java_softwares
            //              where ms.EndsWith("IDE") & js.EndsWith("IDE")
            //              select new { Microsoft = ms, Java = js };
            
            
            #endregion

            #region Require 4 
            //Display first two IDEs from microsoft softwares
            //var results =(from ms in ms_softwares
            //             where ms.EndsWith("IDE")
            //             select ms).Take(2);
            #endregion

            #region Requirement 5


            //Display all the IDES except first 2 from Microsoft
            //var results = (from ms in ms_softwares
            //               where ms.EndsWith("IDE")
            //               select ms).Skip(2);


            #endregion

            int[] numbers = { 35, 5, 23, 9, 5, 2, 1, 10, 45 };
            //var results = numbers.Take(2);

            //TakeWhile starts from 1st number and goes on until the condition is true.
            //var results=numbers.TakeWhile (n =>n>10);


            //var results = numbers.SkipWhile(n => n > 10);

            
            var results = from n in numbers
                          where n > 10
                          select n;
            //The above Linq query is actually follows Defferred execution
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            numbers[4] = 60;
            Console.WriteLine();
            //The below statement will fire the LINQ query again to fetch data from results.
            foreach (var item in results)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
