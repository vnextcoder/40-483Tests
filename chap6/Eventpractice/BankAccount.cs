using System;
using System.Collections.Generic;
using System.Threading;
namespace Eventpractice {
    public class BankAccount {
        public const decimal MaxBalance = 500000;
        public decimal Balance { get; set; }
        public string CustomerId { get; set; }

        public delegate void AccountLimitEventHandler (object sender, OverdrawnEventArgs e);

        public event AccountLimitEventHandler Overdrawn;

        public event AccountLimitEventHandler AccountLimitExceeded;

        protected virtual void OnOverdrawn (OverdrawnEventArgs args) {
            if (Overdrawn != null) Overdrawn (this, args);
        }
        public bool Debit (decimal debitamount) {
            if (debitamount < Balance && Balance > 0) {
                Balance = Balance - debitamount;
                return true;
            } else if (Overdrawn != null) {
                Overdrawn (this, new OverdrawnEventArgs ($"{Thread.CurrentThread.ManagedThreadId} Overdrawn requested ", debitamount, Balance));
                return false;
            } else
                return false;
        }

        public bool Credit (decimal creditamount) {
            if (creditamount + Balance > MaxBalance && AccountLimitExceeded != null) {
                AccountLimitExceeded (this, new OverdrawnEventArgs ($"{Thread.CurrentThread.ManagedThreadId} Account limit exceeded", creditamount, Balance));
                return false;
            } else {
                Balance += creditamount;
                return true;
            }
        }

    }

}