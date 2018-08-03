using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLF
{

    class Employee
    {
        #region Automatic Properties
        
        public int EID { get; set; }
        public string ENAME { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }

        #endregion
        #region Methods
        public override string ToString()
        {
            return String.Format("EID: {0}\tEName:{1}\tSalary:{2}\tAge:{3}", EID, ENAME, Salary, Age);
            //return base.ToString();
        }
        #endregion 
    }
}
