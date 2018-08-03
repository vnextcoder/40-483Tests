using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace LinqtoSQLConsole
{
    [Table(Name="Customers")]
    class Customer
    {
        #region Automatic Properties
        [Column(IsPrimaryKey=true)]
        public string CustomerID  { get; set; }
        [Column]
        public string CompanyName { get; set; }
        [Column]
        public string ContactPerson { get; set; }
        #endregion
    }
}
