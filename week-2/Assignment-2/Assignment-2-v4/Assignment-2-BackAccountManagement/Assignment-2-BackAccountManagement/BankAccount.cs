using System;
using System.Collections.Generic;

namespace Assignment_2_BackAccountManagement
{
    // --> Demonstrating Inheritance
    // 'is-a' relation: strong bounding: inheritance
    // this is a base class for all type of bank accounts
    // inheriting IBankAccount interface
    // --> Demonstrating Abstraction
    // creating an abstract class demonstrating Abstraction
    // default access type: internal
    abstract class BankAccount : IBankAccount
    {
        // constructor
        // cannot be private, called when an object of bank account is created
        public BankAccount(string number, string name, float balance)
        {
            // initializing variables when a bank account is created
            accountNumber = number;
            accountBalance = balance;
            accountHolderName = name;
            transactionsHistory = new List<Transaction>();
            accountsCount++;
        }

        // fields

        // --> Demonstrating Encapsulation
        // hiding sensitive data
        // using private access specifier so that only this class can access the variables
        // using getter and setter methods to access and update private variables
        private readonly string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
        }
        private readonly string accountHolderName;
        public string AccountHolderName
        {
            get { return accountHolderName; }
        }
        private float accountBalance;
        public float AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
        }
        // created a static variable to track the total number of bank accounts
        // static variables are shared with all objects
        private static int accountsCount = 0;
        public static int AccountCount
        {
            get { return accountsCount; }
            set { _ = value; }
        }
        private readonly List<Transaction> transactionsHistory; // this list will store Transaction objects

        // methods
        // --> Demonstrating Polymorphism
        // creating virtual and abstract methods that can be overriden in child classes
        // run-time compiler decides which method to run
        // cannot use virtual with the static, abstract, private or override modifiers
        public abstract void Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract void BankCharges(float amount);


        // Abstract Methods: Demonstrating Abstraction
        // signatures only, connot have method body.
        // must be overriden in child classes.
        public abstract float CalculateInterest();
        public abstract void DisplayAccountInfo();

        public void AddTransaction(TransactionType type, float amount)
        {
            // adds Transaction object to the transactonHistory list
            transactionsHistory.Insert(0, new Transaction(type, amount));
        }

        // --> Demonstrating Polymorphism
        // overloading: same name methods with different number or type of arguments
        // static polymorphism: compile-time polymorphism

        // Prints transaction history to the screen
        public void ShowTransactionHistory()
        {
            // it will show last 5 transaction
            Console.WriteLine("----Transaction History----\n");
            int count = transactionsHistory.Count >= 5 ? 5 : transactionsHistory.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                Console.WriteLine(transactionsHistory[i].Date);
                Console.WriteLine("Type: {0}, Amount: ${1}\n", transactionsHistory[i].Type, transactionsHistory[i].Amount);
            }
        }
        // method to show desired number of transactions
        public void ShowTransactionHistory(int N)
        {
            Console.WriteLine("----Transaction History----\n");
            if (transactionsHistory.Count >= N)
            {
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine("Type: {0}, Amount: ${1}", transactionsHistory[i].Type, transactionsHistory[i].Amount);
                }
            }
            else if (transactionsHistory.Count >= 1)
            {
                foreach (Transaction transaction in transactionsHistory)
                {
                    Console.WriteLine($"Type: {transaction.Type}, Amount: ${transaction.Amount}");
                }
            }
            else
            {
                Console.WriteLine("No Transaction found!");
            }

        }
    }

}
