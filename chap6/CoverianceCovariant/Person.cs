using System;

namespace CoverianceCovariant {

    class Base{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public Person(string first, string last){
        //     FirstName=first;
        //     LastName=last;
        // }
    }
    class Derived:Base{
        public string Department { get; set; }
        // public Employee(string first, string last, string dept):base(first,last)
        // {
        //     Department=dept;
        // }
    }
}