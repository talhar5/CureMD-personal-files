using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_BackAccountManagement
{
    abstract class BankAccount : IBankAccount
    {
        // constructor
        public BankAccount(string number, string name, float balance)
        {
            accountNumber = number;
            accountBalance = balance;
            accountHolderName = name;
            transactionsHistory = new List<Transaction>();
        }

        // fields
        private string accountNumber;
        public string AccountNumber
        {
            get { return accountNumber; }
        }
        private string accountHolderName;
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
        private List<Transaction> transactionsHistory;

        // methods
        public virtual void Deposit(float amount)
        {
            accountBalance += amount;
            Console.WriteLine("Funds have been deposited");
            AddTransaction("Deposit", amount);
        }
        public virtual void Withdraw(float amount)
        {
            if (accountBalance < amount)
            {
                Console.WriteLine("Insufficient Balance");
                return;
            }
            accountBalance -= amount;
            Console.WriteLine("Amount has been deposited.");
            AddTransaction("Withdraw", amount);
        }

        public abstract float CalculateInterest();

        public string getAccountNumber()
        {
            return accountNumber;
        }
        public string getAccountName()
        {
            return accountHolderName;
        }
        public float getBalance()
        {
            return accountBalance;
        }
        public List<Transaction> GetTransactions()
        {
            return transactionsHistory;
        }
        public void AddTransaction(string type, float amount)
        {
            transactionsHistory.Add(new Transaction(type, amount));
        }

        public abstract void DisplayAccountInfo();


    }

}
