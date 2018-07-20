using System;

namespace Extensions
{
	public static class Util
	{
		// TODO:

        public static int Negate(this int i)
        {
            return -i;
        }
        public static int ConverttoBase(this int orgnumber, int newBase)
        {

            if (newBase < 2 || newBase > 10)
                throw new ArgumentOutOfRangeException("newBase", "newBase should be between 2 and 9 (inclusive)");


            int ConvertedNumber = 0;

            int i = 0;

            do
            {
                int remainder = orgnumber % newBase;
                orgnumber = orgnumber / newBase;

                ConvertedNumber += remainder * (int)Math.Pow(10, i);
                i++;
            } while (orgnumber != 0);
            return ConvertedNumber;
        
        
        }
	}

}