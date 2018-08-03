using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace LinqtoSQLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext msops_dc = new DataContext("Server=.;Database=MSOPS;Integrated Security=true");
            //Table<Customer> cust = msops_dc.GetTable<Customer>();
            var cust = msops_dc.GetTable<Customer>().Where(c=> c.CustomerID.StartsWith("B"));
            foreach (Customer c in cust)
            {
                Console.WriteLine(c.CustomerID + "\t" + c.CompanyName + "\t" +  c.ContactPerson);
            }
            Console.ReadKey();
            

        }
    }
}
