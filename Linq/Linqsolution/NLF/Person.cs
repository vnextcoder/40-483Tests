using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NLF
{
    class Person
    {
        #region Automatic Properties
        public string Name { get; set; }
        public int Age { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return String.Format("Name:{0}\tAge:{1}", Name, Age);
            //return base.ToString();
        }
        #endregion 
    }
}
