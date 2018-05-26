using System;
using System.Runtime.ExceptionServices;

namespace Eventpractice {
    public class OverdrawnEventArgs {

        public decimal TransactionAmount { get; private set; }
        public decimal CurrentBalance { get; private set; }
        public OverdrawnEventArgs (string s, decimal txnamount, decimal currentBalance) { Text = s; TransactionAmount = txnamount; CurrentBalance = currentBalance; }
        public String Text { get; private set; } // readonly
    }
}