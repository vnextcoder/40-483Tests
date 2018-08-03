using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linqsamples
{
    class Program
    {
        static void Main(string[] args)
        {

            //XmlLInq();
            //Linqcollection();


            //fib();
            //NestedLInqCollection();

            //NewandIntoLinqcolection();

            Joins();

            Groupbysample();
            Orderbysample();
            groupordersample();
            Console.ReadKey();

        }
        private static void Groupbysample()
        {
            Ingredient[] ingredients = { new Ingredient{Name = "Sugar", Calories=500},
                new Ingredient{Name = "Lard", Calories=500},
                new Ingredient{Name = "Butter", Calories=500},
                new Ingredient{Name = "Egg", Calories=100},
                new Ingredient{Name = "Milk", Calories=100},
                new Ingredient{Name = "Flour", Calories=50},
                new Ingredient{Name = "Oats", Calories=50} };

            var grbyquery = from i in ingredients
                            group i by i.Calories;


            Console.WriteLine("Group ingredients by calories");
            foreach (var item in grbyquery)
            {
                Console.WriteLine("Ingrediants with {0} calories ", item.Key);

                foreach (var item2 in item)
                {
                    Console.WriteLine(" --- > " + item2.Name);
                }

            }

        }
        private static void Orderbysample()
        {
            Ingredient[] ingredients = { new Ingredient{Name = "Sugar", Calories=500}, new Ingredient{Name = "Lard", Calories=500}, new Ingredient{Name = "Butter", Calories=500}, new Ingredient{Name = "Egg", Calories=100},
                new Ingredient{Name = "Milk", Calories=100}, new Ingredient{Name = "Flour", Calories=50}, new Ingredient{Name = "Oats", Calories=50} };

            var grbyquery = from i in ingredients
                            orderby i.Calories descending, i.Name ascending
                            select i;



            Console.WriteLine("ordered ingredients by calories");
            foreach (var item in grbyquery)
            {
                Console.WriteLine("Ingrediant {0} calories {1}", item.Name, item.Calories);


            }

        }

        private static void groupordersample()
        {
            Ingredient[] ingredients = { new Ingredient { Name = "Sugar", Calories = 500 }, new Ingredient { Name = "Lard", Calories = 500 }, new Ingredient { Name = "Butter", Calories = 500 }, new Ingredient { Name = "Egg", Calories = 100 }, new Ingredient { Name = "Milk", Calories = 100 }, new Ingredient { Name = "Flour", Calories = 50 }, new Ingredient { Name = "Oats", Calories = 50 } };


            IEnumerable<IGrouping<int, Ingredient>> query = from i in ingredients
                                                            orderby i.Name ascending
                                                            group i by i.Calories
                                                            into calorieGroup
                                                            orderby calorieGroup.Key descending
                                                            select calorieGroup;
            Console.WriteLine("Grouped  & ordered by calories ");
            foreach (IGrouping<int, Ingredient> group in query)
            {
                Console.WriteLine("Ingredients with {0} calories", group.Key);
                foreach (Ingredient ingredient in group)
                {
                    Console.WriteLine(" - {0}", ingredient.Name);
                }
            }
        }
        private static void Joins()
        {
            Recipe[] recipes = {
                new Recipe { Id = 1, Name = "Mashed Potato" },
                new Recipe { Id = 2, Name = "Crispy Duck" },
                new Recipe { Id = 3, Name = "Sachertorte" }
            };


            Review[] reviews = {
                new Review { RecipeId = 1, ReviewText = "Tasty!" },
                new Review { RecipeId = 1, ReviewText = "Not nice :(" },
                new Review { RecipeId = 1, ReviewText = "Pretty good" },
                new Review { RecipeId = 2, ReviewText = "Too hard" },
                new Review { RecipeId = 2, ReviewText = "Loved it" }
            };


            var query = from recipe in recipes
                        join review in reviews on recipe.Id equals review.RecipeId
                        select new
                        {
                            recipe = recipe.Name,
                            Reviewresult = review.ReviewText

                        };
            Console.WriteLine("Flat JOin");
            foreach (var item in query)
            {
                Console.WriteLine(" recipe {0} review result {1} ", item.recipe, item.Reviewresult);

            }
            Console.WriteLine("Heirarchical Join");


            var query2 = from recipe in recipes
                         join review in reviews on recipe.Id equals review.RecipeId
                         into Reviewgroups
                         select new
                         {
                             recipe = recipe.Name,
                             Reviews = Reviewgroups

                         };

            foreach (var item in query2)
            {
                Console.WriteLine(" Reviews for recipe {0} ", item.recipe);
                foreach (var item2 in item.Reviews)
                {
                    Console.WriteLine(" -- Reviewed {0} ", item2.ReviewText);

                }

            }

            Console.WriteLine("Flat Left - Outer Join");


            var query3 = from recipe in recipes
                         join review in reviews on recipe.Id equals review.RecipeId
                         into Reviewgroups
                         from rg in Reviewgroups.DefaultIfEmpty(new Review { ReviewText = "n/a" })
                         select new
                         {
                             recipe = recipe.Name,
                             //Review = rg == null ? "n/a" : rg.ReviewText,
                             Review = rg.ReviewText

                         };

            foreach (var item in query3)
            {
                Console.WriteLine(" recipe {0} review result {1} ", item.recipe, item.Review);

            }


        }

        class Recipe { public int Id { get; set; } public string Name { get; set; } }

        class Review { public int RecipeId { get; set; } public string ReviewText { get; set; } }

        private static void NewandIntoLinqcolection()
        {
            Ingredient[] Ingredients = new Ingredient[]
                {
                    new Ingredient() {  Name="Sugar", Calories=500},
                    new Ingredient{Name = "Egg", Calories=100},
                    new Ingredient{Name = "Milk", Calories=150},
                    new Ingredient{Name = "Flour", Calories=50},
                    new Ingredient{Name = "Butter", Calories=200}

                };


            var highDairy = from i in Ingredients
                            select new
                            {
                                ingredientname = i.Name,
                                isDairy = i.Name == "Milk" || i.Name == "Butter",
                                isHighCalory = i.Calories >= 150

                            }
                            into dairyprods
                            where dairyprods.isDairy && dairyprods.isHighCalory
                            select dairyprods.ingredientname;

            foreach (var dairyIngredient in highDairy)
            {
                Console.WriteLine("{0} is dairy with high calories", dairyIngredient);
            }
        }

        private static void NestedLInqCollection()
        {
            string[] csvRecipes =
                { "milk,sugar,eggs",
                "flour,BUTTER,eggs",
                "vanilla,ChEEsE,oats" };

            var dairyQuery = from csvRecipe in csvRecipes
                             let ingredients = csvRecipe.Split(',')
                             from ingredient in ingredients
                                 //let uppercaseIngredient = ingredient.ToUpper()
                             where ingredient.Equals("MILK", StringComparison.CurrentCultureIgnoreCase)
                             || ingredient.Equals("BUTTER", StringComparison.CurrentCultureIgnoreCase)
                             || ingredient.Equals("CHEESE", StringComparison.CurrentCultureIgnoreCase)
                             //|| uppercaseIngredient == "CHEESE"
                             select ingredient;

            foreach (var dairyIngredient in dairyQuery)
            {
                Console.WriteLine("{0} is dairy", dairyIngredient);
            }
        }

        private static void fib()
        {
            int[] fibonacci = { 0, 1, 1, 2, 3, 5 };
            //var greaterthan2 = fibonacci.Where(i => i > 2);
            var greaterthan2 = fibonacci.Where(new Func<int, bool>(greaterthan2check));
            fibonacci[0] = 99;

            foreach (var item in greaterthan2)
            {
                Console.WriteLine(item);

            }
        }

        private static void XmlLInq()
        {
            var xml = @"
                <ingredients> 
                    <ingredient name='milk' quantity='200' price='2.99' /> 
                    <ingredient name='sugar' quantity='100' price='4.99' /> 
                    <ingredient name='safron' quantity='1' price='46.77' /> 
                </ingredients>";
            XElement xmlData = XElement.Parse(xml);
            XElement milk = xmlData.Descendants("ingredient").First(x => x.Attribute("name").Value == "milk");

            XAttribute nameAttribute = milk.FirstAttribute; // name attribute 
            XAttribute priceAttribute = milk.Attribute("price");
            string priceOfMilk = priceAttribute.Value; // 2.99 
            XAttribute quantity = milk.Attributes().Skip(1).First(); // quantity attribute



        }

        static bool greaterthan2check(int i)
        {
            return i > 2;
        }
        static void Linqcollection()
        {
            Ingredient[] Ingredients = new Ingredient[]
                {
                    new Ingredient() {  Name="Sugar", Calories=500},
                    new Ingredient{Name = "Egg", Calories=100},
                    new Ingredient{Name = "Milk", Calories=150},
                    new Ingredient{Name = "Flour", Calories=50},
                    new Ingredient{Name = "Butter", Calories=200}

                };

            var highCalorieIngredientNamesQuery = Ingredients.Where(i => i.Calories >= 150).OrderBy(i => i.Name).Select(i => i.Name);


            Console.WriteLine("fluent style");
            foreach (var item in highCalorieIngredientNamesQuery)
            {
                Console.WriteLine(item);
            }
            var high = from i in Ingredients
                       where i.Calories >= 150
                       orderby i.Name
                       select i.Name;

            Console.WriteLine("query style");
            foreach (var item in high)
            {
                Console.WriteLine(item);
            }

            var highonlyDairy = from i in Ingredients
                                let isDairy = i.Name == "Milk" || i.Name == "Butter"
                                where i.Calories >= 150 && isDairy
                                orderby i.Name
                                select i.Name;

            Console.WriteLine("query style with let");
            foreach (var item in highonlyDairy)
            {
                Console.WriteLine(item);
            }


        }

        class Ingredient { public string Name { get; set; } public int Calories { get; set; } }





    }
}
