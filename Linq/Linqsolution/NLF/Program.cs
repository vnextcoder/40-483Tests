using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

//Every class implementing IEnumerable interface to be called into Lambda Expressions.
namespace NLF
{

    //class Customer
    //{

    //    public int Id; 
    //    public string Name;
    //    public string Address;
    //    public Orders [] orders;
    //}

    //class Orders 
    //{
    //    public int ID;
    //    public string Name;
    //    public decimal Value;
    //}

    public class Program
    {

        static bool FilterbySalary(Employee e)
        {
            return e.Salary > 7000;
        }
        static bool FilterbyName(Employee e)
        {
            return e.ENAME.StartsWith("S");
        }
        
        static void Main(string[] args)
        {
        //    Employee e = new Employee();
            #region Object Initializer
            //Employee e=new Employee{EID=3456, ENAME="Scott", Salary=9000, Age=25};
            //Console.WriteLine(e);
            
            #endregion

            #region Array Initializers
            //Dense Array = Array with ready.
            //Employee[] empArray = new Employee[]
            //{
            //    new Employee{EID=4566, ENAME="Scott", Salary=6000, Age=24},
            //    new Employee{EID=4568, ENAME="Allen", Salary=7000, Age=25},
            //    new Employee{EID=4563, ENAME="Blake", Salary=8000, Age=26},
            //    new Employee{EID=452, ENAME="King", Salary=9000, Age=28},
            
            
            //};
            //foreach (Employee em in empArray)
            //{
            //    Console.WriteLine(em);

            //}
            

            #endregion

            #region Non-Generic Collection Initializer
            //ArrayList empArray = new ArrayList
            //{
            //    new Employee{EID=4566, ENAME="Scott", Salary=6000, Age=24},
            //    new Employee{EID=4568, ENAME="Allen", Salary=7000, Age=25},
            //    new Employee{EID=4563, ENAME="Blake", Salary=8000, Age=26},
            //    new Employee{EID=452, ENAME="King", Salary=9000, Age=28},
            
            
            
            //};
            //foreach (Employee em in empArray)
            //{
            //    Console.WriteLine(em);

            //}
            #endregion 
            
            
            #region Generic Collection Initializer
            List<Employee> empList = new List<Employee>
            {
                new Employee{EID=4566, ENAME="Scott", Salary=6000, Age=24},
                new Employee{EID=4568, ENAME="Allen", Salary=7000, Age=25},
                new Employee{EID=4563, ENAME="Blake", Salary=8000, Age=26},
                new Employee{EID=4562, ENAME="King", Salary=9000, Age=28},
                new Employee{EID=4564, ENAME="Steve", Salary=8500, Age=27},
            };

            //List<Employee> filteredlist = new List<Employee>();
            //foreach (Employee emp in empList)
            //{   
            //    if(emp.ENAME.StartsWith("S"))
            //    {
            //        filteredlist.Add(emp);
            //    }
		 
            //}

            List<Employee> filteredlist;
            //filteredlist = Utilities.Where(empList, FilterbyName);
            
            //Anonymous Methods
            //filteredlist = Utilities.Where(empList,
            //    delegate(Employee e)
            //    {
            //        //Multiple statements
            //        return e.Salary > 8000;
            //    }
            //    );


            //Lambda Expression: (Parameter List ) => {statements}
            //filteredlist = Utilities.Where(empList,
            //    (Employee e)=>
            //    {
            //        //Multiple statements
            //        return e.Salary > 8000;
            //    }
            //    );

            //When the anonymous method has only one statement - Same IL Code would be generated
            //filteredlist = Utilities.Where(empList,
            //    (Employee e) =>  e.Salary > 8000);

            //Same IL as above again. with getting rid of Type and brackets.
            //Compiler gets the type from the Delegate signature.
            //filteredlist = Utilities.Where(empList,
            //    e => e.Salary > 8000);



            //List<Person> plist = Utilities.Select(filteredlist,
            //    e =>
            //        new Person { Name = e.ENAME, Age = e.Age }
            //);
            


            //List<Person> plist = Utilities.Select(Utilities.Where(empList,
            //            e => e.Salary > 8000),
            //            e =>
            //        new Person { Name = e.ENAME, Age = e.Age }
            //);

            //List<Person> plist = empList
            //                .Where (e => e.Salary > 8000)
            //                .Select(e => new Person { Name = e.ENAME, Age = e.Age }
            //    );

            
            
            
            ////filteredlist = empList.Where(FilterbySalary);
            //foreach (Person em in plist)
            //{
            //    Console.WriteLine(em);
            //}

            //foreach (Person em in plist)
            //{
            //    Console.WriteLine(em);
            //}

            //Implicit Typing
            //var <variable_name> = <expression/value>;
            //var plist = empList
            //                .Where(e => e.Salary > 8000)
            //                .Select(e => new { Name = e.ENAME, Age = e.Age }
            //    );

            //Standard LinQ statement with my own Utilities Class
            var plist = from e in empList
                            where e.Salary > 8000
                            select new { Name = e.ENAME, Age = e.Age };

            //Standard LINQ statement using where and select as UDFs, 
            //whereas orderby from System.Linq namespace.
            var plist2 = from e in empList
                        where e.Salary > 8000
                        orderby e.ENAME
                        select new { Name = e.ENAME, Age = e.Age };
            

            foreach (var em in plist)
            {
                Console.WriteLine(em);
            }


            //Use Generic 
            //List<string> softwares = new List<string>
            //{
            //    "MS word 2007",
            //    "MS office 2010",
            //    "MS Excel 2010",
            //    "MS Office 2007"
            
            //};

            //List<string> result = softwares.Where(s => s.EndsWith("2010"));
            //foreach (string em in result)
            //{
            //    Console.WriteLine(em);
            //}

            #endregion 


            //someclass someobject = new someclass();
            //someobject.MyProperty[0] = 1;
            //someobject.MyProperty[1] = 2;

            //Console.WriteLine(someobject.MyProperty[0].ToString());
            //Console.WriteLine(someobject.MyProperty[1].ToString());


            
            //string message = "Hello World!";
            //Console.WriteLine(message.Reverse());
            //Console.WriteLine(message.Reverse(4));
            //Action a;

            //Func<string> f;
            Console.ReadKey();
        }
    }
}
