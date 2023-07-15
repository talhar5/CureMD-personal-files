using System;

namespace Assignment_2_BackAccountManagement
{
    // this class is used to store details of a single transaction
    // each time a transaction is made, a new object of this class is created
    // and stored in a list transactionHistory in BankAccount class
    class Transaction
    {
        // Constructor
        // constructor cannot be private
        public Transaction(TransactionType type, float amount)
        {
            // initializing the variables
            this.type = type;
            this.amount = amount;
            this.date = DateTime.Now;
        }

        // --> Demonstrating Encapsulation
        // Hiding sensitive data
        // using private access specifier to limit the access of the variables
        // using public getter method to access the the private variables
        private readonly TransactionType type;
        public TransactionType Type
        {
            get { return type; }
            set { _ = value; }
        }
        private readonly float amount;
        public float Amount
        {
            get { return amount; }
            set { _ = value; }
        }
        private readonly DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { _ = value; }
        }
    }
}
