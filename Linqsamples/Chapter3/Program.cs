using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            //WhereSample();
            //SelectClass_Anonymous();

            //SelectMany();
            // Takeex();
            //takewhileEX();
            //Skipex();

            //Pagination();
            //Skipwhileex();
            //OrderByEx();
            //ThenByEx();

            ReverseEx();

            GroupbyEx();
            Console.ReadKey();
        }

        private static void GroupbyEx()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 },
                new Ingredient { Name = "Lard", Calories = 500 },
                new Ingredient { Name = "Butter", Calories = 500 },
                new Ingredient { Name = "Egg", Calories = 100 },
                new Ingredient { Name = "Milk", Calories = 100 },
                new Ingredient { Name = "Flour", Calories = 50 },
                new Ingredient { Name = "Oats", Calories = 50 }
            };


        }

        private static void ReverseEx()
        {
            char[] letters = { 'A', 'B', 'C' };
            var query = letters.Reverse();
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            int[] numbers = { 1, 230, 23 };

            var query2 = numbers.Reverse();

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }

        }

        private static void ThenByEx()
        {
            Ingredient[] ingredients = {
                new Ingredient { Name = "Sugar", Calories = 500 },
                new Ingredient { Name = "Milk", Calories = 100 },
                new Ingredient { Name = "Egg", Calories = 100 },
                new Ingredient { Name = "Flour", Calories = 500 },
                new Ingredient { Name = "Butter", Calories = 200 } };

            Console.WriteLine("Thenby demo");
            var query = ingredients
                    .OrderBy(x => x.Calories)
                    .ThenByDescending(x => x.Name);


            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " " + item.Calories);
            }
            var query2 = from x in ingredients
                         orderby x.Calories, x.Name descending
                         select x;



            foreach (var item in query2)
            {
                Console.WriteLine(item.Name + " " + item.Calories);
            }

        }

        private static void OrderByEx()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 }, new Ingredient { Name = "Egg", Calories = 100 }, new Ingredient { Name = "Milk", Calories = 150 }, new Ingredient { Name = "Flour", Calories = 50 }, new Ingredient { Name = "Butter", Calories = 200 } };

            var query = ingredients.OrderBy(x => x.Calories);
            Console.WriteLine("Order by Linq");
            foreach (var item in query)
            {
                Console.WriteLine(item.Name + " " + item.Calories);
            }

        }

        private static void Skipwhileex()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 }, new Ingredient { Name = "Egg", Calories = 100 }, new Ingredient { Name = "Milk", Calories = 150 }, new Ingredient { Name = "Flour", Calories = 50 }, new Ingredient { Name = "Butter", Calories = 200 } };
            Console.WriteLine("skip while demo");
            IEnumerable<Ingredient> query = ingredients.SkipWhile(x => x.Name != "Milk");

            foreach (var ingredient in query)
            {
                Console.WriteLine(ingredient.Name);
            }
        }
        private static void Pagination()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 }, new Ingredient { Name = "Egg", Calories = 100 }, new Ingredient { Name = "Milk", Calories = 150 }, new Ingredient { Name = "Flour", Calories = 50 }, new Ingredient { Name = "Butter", Calories = 200 } };

            var firstPage = ingredients.Take(2);
            var secondPage = ingredients.Skip(2).Take(2);
            var thirdPage = ingredients.Skip(4).Take(2);
            Console.WriteLine("Pagination via Linq");
            Console.WriteLine("Page One:"); foreach (var ingredient in firstPage) { Console.WriteLine(" - " + ingredient.Name); }
            Console.WriteLine("Page Two:"); foreach (var ingredient in secondPage) { Console.WriteLine(" - " + ingredient.Name); }
            Console.WriteLine("Page Three:"); foreach (var ingredient in thirdPage) { Console.WriteLine(" - " + ingredient.Name); }



        }

        private static void Skipex()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 },
                new Ingredient { Name = "Egg", Calories = 100 },
                new Ingredient { Name = "Milk", Calories = 150 },
                new Ingredient { Name = "Flour", Calories = 50 },
                new Ingredient { Name = "Butter", Calories = 200 } };

            Console.WriteLine("Skip sample");
            var query = ingredients
                .Where(x => x.Calories > 100)
                .Skip(2);
            foreach (var item in query)
            {
                Console.WriteLine("INgredient {0} Calories {1}", item.Name, item.Calories);
            }
        }
        private static void takewhileEX()
        {

            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 },
                new Ingredient { Name = "Egg", Calories = 100 },
                new Ingredient { Name = "Milk", Calories = 150 }, new Ingredient { Name = "Flour", Calories = 50 }, new Ingredient { Name = "Butter", Calories = 200 } };

            Console.WriteLine("Takewhile Calories >=100");
            IEnumerable<Ingredient> query = ingredients.TakeWhile(x => x.Calories >= 100);

            foreach (var item in query)
            {
                Console.WriteLine("INgredient {0} Calories {1}", item.Name, item.Calories);
            }



        }
        private static void Takeex()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 },
                new Ingredient { Name = "Egg", Calories = 100 },
                new Ingredient { Name = "Milk", Calories = 150 },
                new Ingredient { Name = "Flour", Calories = 50 },
                new Ingredient { Name = "Butter", Calories = 200 } };

            Console.WriteLine("Take sample");
            var query = ingredients
                .Where(x => x.Calories >= 100).Take(2);
            foreach (var item in query)
            {
                Console.WriteLine("INgredient {0} Calories {1}", item.Name, item.Calories);
            }


            Console.WriteLine("Take sample with mixed query/fluent . No Take keyword for query style");
            var query2 = (from i in ingredients
                          where i.Calories >= 100
                          select i)
                         .Take(2);


            foreach (var item in query2)
            {
                Console.WriteLine("INgredient {0} Calories {1}", item.Name, item.Calories);
            }




        }

        private static void SelectMany()
        {
            string[] ingredients = { "Sugar", "Egg", "Milk", "Flour", "Butter" };
            Console.WriteLine("Select Many chars Fluent version ");

            var query = ingredients.SelectMany(x => x.ToCharArray());




            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Select Many chars query version ");
            var query2 = from s in ingredients
                         from c in s.ToCharArray()
                         select c;

            foreach (var item in query2)
            {
                Console.WriteLine(item);
            }





        }

        static void SelectClass_Anonymous()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 },
                new Ingredient { Name = "Egg", Calories = 100 },
                new Ingredient { Name = "Milk", Calories = 150 },
                new Ingredient { Name = "Flour", Calories = 50 },
                new Ingredient { Name = "Butter", Calories = 200 }
            };
            Console.WriteLine("Projection with select (Class )");

            var query = ingredients.Where(x => x.Calories > 100)
                .Select(x => new IngredientnameandLength
                {

                    Name = x.Name,
                    len = x.Name.Length

                });

            foreach (var item in query)
            {
                Console.WriteLine(" ingredient {0} length {1}", item.Name, item.len);
            }
            Console.WriteLine("Projection with select (Anonymous)");

            var query2 = ingredients.Where(x => x.Calories > 100)
                .Select(x => new
                {

                    Name = x.Name,
                    len = x.Name.Length

                });

            foreach (var item in query2)
            {
                Console.WriteLine(" ingredient {0} length {1}", item.Name, item.len);
            }


            Console.WriteLine("Projection with select (query syntax)");

            var query3 = from x in ingredients
                         where x.Calories > 100
                         select new
                 IngredientnameandLength
                         {

                             Name = x.Name,
                             len = x.Name.Length

                         };

            foreach (var item in query3)
            {
                Console.WriteLine(" ingredient {0} length {1}", item.Name, item.len);
            }
        }
        static void WhereSample()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 },
                new Ingredient { Name = "Egg", Calories = 100 },
                new Ingredient { Name = "Milk", Calories = 150 },
                new Ingredient { Name = "Flour", Calories = 50 },
                new Ingredient { Name = "Butter", Calories = 200 }
            };
            Console.WriteLine("Where sample");
            IEnumerable<Ingredient> query = ingredients.Where(x => x.Calories >= 200);
            foreach (var ingredient in query)
            {
                Console.WriteLine(ingredient.Name);
            }

            IEnumerable<Ingredient> query2 = ingredients
                                .Where((ingredient, index) =>
                               ingredient.Name == "Sugar" || index == 4);

            Console.WriteLine("Where by INdex ");

            foreach (var ingredient in query2)
            {
                Console.WriteLine(ingredient.Name);
            }
        }
    }

    internal class Ingredient
    {
        public int Calories { get; set; }
        public string Name { get; set; }
    }

    internal class IngredientnameandLength
    {
        public int len { get; set; }
        public string Name { get; set; }
    }

}
