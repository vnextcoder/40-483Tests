using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLF
{

    //delegate bool Filter(Employee e);
    //delegate Person Convert(Employee emp);

    delegate bool Filter<T>(T t);
    delegate T2 Convert<T1, T2>(T1 emp);
    static class Utilities
    {
        //if (Filter != null)
        //{
        //    Filter();
        //}

        #region Non-Generic Form
        
        
        //public static List<Employee> Where(this List<Employee> srcEmpList, Filter filter)
        //{
        //    if (filter == null)
        //    {
        //        throw new ArgumentNullException("Hello the Filter is not provided");
        //    }

        //    List<Employee> result = new List<Employee>();
        //    foreach (Employee e in srcEmpList)
        //    {
        //        if (filter(e))
        //            result.Add(e);
        //    }
        //    return result;
        //}

        //public static List<Person> Select(this List<Employee> srcEmpList, Convert convert)
        //{
        //    if (convert == null)
        //    {
        //        throw new ArgumentNullException("Hello the Conversion is not provided");
        //    }
        //    List<Person> selectedPersons = new List<Person>();
        //    foreach (Employee e in srcEmpList)
        //    {
        //        selectedPersons.Add(convert(e));
        //    }
        //    return selectedPersons;

        //}
        #endregion
        #region Generic Form Mthods
        public static List<T> Where<T>(this List<T> srcEmpList, Filter<T> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException("Hello the Filter is not provided");
            }

            List<T> result = new List<T>();
            foreach (T e in srcEmpList)
            {
                if (filter(e))
                    result.Add(e);
            }
            return result;
        }

        public static List<T2> Select<T1,T2>(this List<T1> srcEmpList, Convert<T1,T2> convert)
        {
            if (convert == null)
            {
                throw new ArgumentNullException("Hello the Conversion is not provided");
            }
            List<T2> selectedPersons = new List<T2>();
            foreach (T1 e in srcEmpList)
            {
                selectedPersons.Add(convert(e));
            }
            return selectedPersons;

        }
        #endregion

    }
}
