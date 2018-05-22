using System;

namespace ICompareableCars {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ("Hello World!");

            Car[] cars = new Car[] {
                new Car () { Name = "SSC Ultimate Aero", MaxMph = 257, HorsePower = 1183, Price = 654400m },
                new Car () { Name = "Bugatti Veyron", MaxMph = 253, HorsePower = 1001, Price = 1700000m },
                new Car () { Name = "Saleen S7 Twin-Turbo", MaxMph = 248, HorsePower = 750, Price = 555000m },
                new Car () { Name = "Koenigsegg CCX", MaxMph = 245, HorsePower = 806, Price = 545568m },
                new Car () { Name = "McLaren F1", MaxMph = 240, HorsePower = 637, Price = 970000m },
                new Car () { Name = "Ferrari Enzo", MaxMph = 217, HorsePower = 660, Price = 670000m },
                new Car () { Name = "Jaguar XJ220", MaxMph = 217, HorsePower = 542, Price = 650000m },
                new Car () { Name = "Pagani Zonda F", MaxMph = 215, HorsePower = 650, Price = 667321m },
                new Car () { Name = "Lamborghini Murcielago LP640", MaxMph = 211, HorsePower = 640, Price = 430000m },
                new Car () { Name = "Porsche Carrera GT", MaxMph = 205, HorsePower = 612, Price = 440000m },

            };

            Console.WriteLine ("Default Array");
            Array.ForEach (cars, Console.WriteLine);

            Array.Sort (cars);
            Console.WriteLine ("sorted Array");
            Array.ForEach (cars, Console.WriteLine);


            CarPriceComparer comparer=new CarPriceComparer();

            comparer.SortBy=CarPriceComparer.CompareField.MaxMph;
            Array.Sort(cars,comparer);
            Console.WriteLine ("sorted by Mph ");
            Array.ForEach (cars, Console.WriteLine);


            comparer.SortBy=CarPriceComparer.CompareField.Horsepower;
            Array.Sort(cars,comparer);
            Console.WriteLine ("sorted by HP");
            Array.ForEach (cars, Console.WriteLine);

            comparer.SortBy=CarPriceComparer.CompareField.Price;
            Array.Sort(cars,comparer);
            Console.WriteLine ("sorted by Price ");
            Array.ForEach (cars, Console.WriteLine);

            comparer.SortBy=CarPriceComparer.CompareField.MaxMph;
            Array.Sort<Car>(cars,comparer);
            Array.Reverse<Car>(cars);

            Console.WriteLine ("sorted by maxmph reverse based on generic ");
            Array.ForEach (cars, Console.WriteLine);


        }
    }
}