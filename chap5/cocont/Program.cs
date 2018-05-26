using System;
using System.Collections.Generic;
namespace cocont {

    class Fruit {
        public void whoami () => Console.WriteLine (this.GetType () + " value is " + a);
        public int a { get; set; } = 10;

    }
    class Apple : Fruit {

    }
    class Banana : Fruit {

    }

    public class Dog {
        public string Name { get; set; }

        public void whoami () => Console.WriteLine (this.GetType () + " my name is " + Name);

    }
    public class Poodle : Dog {
        public void DoBackflip () {
            System.Console.WriteLine ("2nd smartest breed - woof!" + Name);

        }
    }

    class Program {
        public static Poodle ConvertDogToPoodle (Dog dog) {
            return new Poodle () { Name = dog.Name };
        }

        public static void ShowDogs (IEnumerable<Dog> dogs) {
            foreach (var item in dogs) {
                item.whoami ();
            }
            //Console.WriteLine(dogs);

        }

        static void Main (string[] args) {

            Dog d = new Dog ();
            d.whoami ();

            //     Apple a = new Apple();
            //     a.whoami();

            //     Banana b = new Banana();
            //     b.whoami();

            //     Fruit f = a;
            //     f.whoami();

            //     Fruit g=b;
            //     g.whoami();

            // List<Fruit> fruitList = new List<Fruit> ();
            // List<Banana> bananaList = new List<Banana> ();
            // fruitList.Add (new Apple ());
            // fruitList.Add (new Apple ());
            // fruitList.Add (new Banana ());
            // fruitList.Add (new Banana ());

            // bananaList.Add(new Apple());
            // bananaList.Add(new Fruit());

            // foreach (var item in fruitList)
            // {
            //     item.whoami();
            // }

            // Fruit f1 = new Apple ();
            // f1.whoami ();

            // Banana b1 = f1;

            List<Dog> dogs = new List<Dog> () { new Dog { Name = "Truffles" }, new Dog { Name = "Fuzzball" } };

            //List<Poodle> poodels = dogs;

            List<Poodle> poodles = dogs.ConvertAll (new Converter<Dog, Poodle> (ConvertDogToPoodle));
            foreach (var poodle in poodles) {
                poodle.DoBackflip ();
            }

            //     List<object> objects =new List<object>();
            //     objects.Add(123);
            //     objects.Add(456);
            //     objects.Add("suresh");
            //     objects.Add("ramesh");

            //     foreach (var item in objects)
            //     {
            //         Console.WriteLine(item.GetType());
            //     }

            //     object obj=123;

            //     int i =(int) obj;

            //     Console.WriteLine(i.GetType());
            //     Console.WriteLine(obj.GetType());

            //    //string s =(string) obj;

            //     Fruit f=new Apple();
            //     Fruit g=new Banana();

            //     Banana b1=(Banana)g;

            // List <Poodle> poodles =new List<Poodle>() { 
            //     new Poodle(){ Name="Poodle 1"},
            //     new Poodle(){Name="Poodle 2"}
            // };

            //ShowDogs(poodles);

        }
    }
}