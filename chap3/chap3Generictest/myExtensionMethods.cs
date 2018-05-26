using System;

namespace Generictest {

    static class myExtensionMethods{

        public static string hash(this string stringVal ){
            string hashvalue=stringVal.Length + stringVal.Substring(0,2);
            return hashvalue;


        }
    }
}