using System;
using System.Collections.Generic;

namespace ICompareableCars {
    public class CarPriceComparer : IComparer<Car> {
        public enum CompareField {
            Name,
            MaxMph,
            Horsepower,
            Price,
        }
        public CompareField SortBy = CompareField.Name;
        public int Compare (Car x, Car y) {

            switch (SortBy) {
                case CompareField.Name:
                    return x.Name.CompareTo (y.Name);
                case CompareField.MaxMph:
                    return x.MaxMph.CompareTo (y.MaxMph);
                case CompareField.Horsepower:
                    return x.HorsePower.CompareTo (y.HorsePower);
                case CompareField.Price:
                    return x.Price.CompareTo (y.Price);
            }
            return x.Name.CompareTo (y.Name);
            
        }
    }

}