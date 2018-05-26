using System;
using System.Collections.Generic;
namespace CoverianceCovariant {
    class Program {

        public class Dog { public string Name { get; set; } }
        public class Poodle : Dog { public void DoBackflip () { System.Console.WriteLine ("2nd smartest breed - woof!");  Console.WriteLine($"name is {Name}");} }

        public static Poodle ConvertDogToPoodle (Dog dog) {
            return new Poodle () { Name = dog.Name };
        }

        // A delegate that returns a Base.
        internal delegate Base ReturnBaseDelegate ();
        internal ReturnBaseDelegate ReturnBaseMethod;

        // A method that returns an Derived.
        internal Derived ReturnDerived () {
            return new Derived ();
        }

        // A delegate that takes an Derived as a parameter.
        internal delegate void DerivedParameterDelegate (Derived Derived);
        internal DerivedParameterDelegate DerivedParameterMethod;
        // Method 2.
        internal Action<Derived> DerivedParameterMethod2;

        internal Action<Base> DerivedParameterMethod3;
        // A method that takes a Base as a parameter.
        internal void BaseParameter (Base Base) {
            Console.WriteLine ($"You are {Base.FirstName + Base.LastName}");
            Console.WriteLine (Base.GetType ());

        }
        static void Main (string[] args) {
            // Console.WriteLine ("Hello World!");
            // Program p = new Program ();
            // p.doContra ();
            // p.coveriance();

            // Action<Base> b = (target) => { Console.WriteLine(target.GetType().Name); };
            // Action<Derived> d = b;
            // d(new Derived());
            // //b(new Base());

            // Action<Derived> d1 = (target) => { Console.WriteLine(target.GetType().Name); };
            // Action<Base> b1 =(Action<Base>)d1 ;

            // b1(new Derived());
            //b1(new  Base());

            List<Dog> dogs = new List<Dog> () { new Dog { Name = "Truffles" }, new Dog { Name = "Fuzzball" } };
            List<Poodle> poodles = dogs.ConvertAll (new Converter<Dog, Poodle> (ConvertDogToPoodle));
            //poodles[0].DoBackflip ();

            foreach (var item in poodles)
            {
                item.DoBackflip();
            }

        }

        public void coveriance () {

            // Use covariance to set ReturnBaseMethod = ReturnDerived.
            ReturnBaseMethod = ReturnDerived;
            ReturnBaseMethod ();
        }
        public void doContra () {
            // Use contravariance to set DerivedParameterMethod = BaseParameter.
            DerivedParameterMethod = BaseParameter;
            DerivedParameterMethod2 = BaseParameter;
            DerivedParameterMethod3 = BaseParameter;

            Base baseo = new Base () { FirstName = "suresh", LastName = "Kumar" };

            Derived derived = new Derived () { FirstName = "rajesh", LastName = "Kumar", Department = "Finance" };

            DerivedParameterMethod (derived);
            DerivedParameterMethod2 (derived);
            DerivedParameterMethod3 (baseo);

        }
    }
}