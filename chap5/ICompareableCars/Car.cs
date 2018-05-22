using System;
using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
namespace ICompareableCars {
    public class Car : IComparable<Car>, IComparable {
        public string Name { get; set; }
        public int MaxMph { get; set; }
        public int HorsePower { get; set; }
        public decimal Price { get; set; }


        public int CompareTo(Car other)
        {
            
            return this.Name.CompareTo(other.Name);

        }
        public int CompareTo(Object obj)
        {
            if (!(obj is Car))
                throw new ArgumentException("Object is not a Car");
            Car other=obj as Car;
            
            return this.Name.CompareTo(other.Name);

        }
        public override string ToString()
        {
            return $" name : {this.Name} Mph : {this.MaxMph}, HP: {this.HorsePower} , Price : {this.Price}";

        }
    }
}