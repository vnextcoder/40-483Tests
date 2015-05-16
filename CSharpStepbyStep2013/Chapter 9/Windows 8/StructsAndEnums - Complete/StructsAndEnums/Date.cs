using System;

namespace StructsAndEnums
{
    class Date
    {
	    private int year;
        private Month month;
        private int day;

        public Date(int ccyy, Month mm, int dd)
        {
            this.year = ccyy - 1900;
            this.month = mm;
            this.day = dd - 1;
        }

        public override string ToString()
        {
            string data = String.Format("{0} {1} {2}", this.month, this.day + 1, this.year + 1900);
            return data;
        }

        public void AdvanceMonth()
        {
            this.month++;
            if (this.month == Month.December)
            {
                this.month = Month.January;
                this.year++;
            }
        }
    }
}