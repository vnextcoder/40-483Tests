using System;
namespace Eventpractice {
    class MoneyMarketAccount : BankAccount {
        public void DebitFee (decimal amount) {
            // See if there is this much money in the account.
            if (Balance >= amount) {
                // Remove the money.
                Balance -= amount;
            } else {
                // Raise the Overdrawn event.
                //Overdrawn (this, new OverdrawnEventArgs ("NO balance for Fee", Balance, amount));
                OnOverdrawn (new OverdrawnEventArgs ($"Overdrawn requested ", Balance, amount));
            }
        }
    }
}