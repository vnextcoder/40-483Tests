using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLF
{
    public static class StringFunctions
    {
        public static string Reverse(this string srcString)
        { 
            char[] chars =srcString.ToCharArray();
            StringBuilder reverse= new StringBuilder();
            for(int i=chars.Length-1;i>=0;i--)
            {
                reverse.Append(chars[i]);
            }
            return reverse.ToString();
        
        }
        public static string Reverse(this string srcString, int noc)
        {
            char[] chars = srcString.ToCharArray();
            StringBuilder reverse = new StringBuilder();
            for (int i = noc - 1; i >= 0; i--)
            {
                reverse.Append(chars[i]);
            }
            return reverse.ToString();

        }
    }
}
