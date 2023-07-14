using System;
using System.Collections.Generic;
namespace Assignment_2_BackAccountManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank MeezanBank = new Bank(); // creating  a bank

            SavingsAccount talhaAccount = new SavingsAccount("PK1122", "Talha Razzaq", 1000, 1.7f); // creating a saving account
            CheckingAccount ashirAccount = new CheckingAccount("PK0105", "Muhammad Ashir", 2000); // creating a checking account

            MeezanBank.AddAccount(talhaAccount); // adding accounts to the bank
            MeezanBank.AddAccount(ashirAccount);

            MeezanBank.DepositToAccount("PK0105", 200);
            MeezanBank.DepositToAccount("PK1122", 150);
            Console.WriteLine();
            MeezanBank.WithdrawFromAccount("PK0105", 9000);
            MeezanBank.WithdrawFromAccount("PK1122", 90);
        }
    }

    public interface IBankAccount
    {
        void Deposit(float amount);
        void Withdraw(float amount);

    }
    abstract class BankAccount : IBankAccount
    {
        // constructor
        public BankAccount(string number, string name, float balance)
        {
            accountNumber = number;
            accountBalance = balance;
            accountHolderName = name;
        }

        // props
        protected string accountNumber;
        protected string accountHolderName;
        protected float accountBalance;

        // methods
        public virtual void Deposit(float amount)
        {
            accountBalance += amount;
            Console.WriteLine("Funds have been deposited");
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
        }

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

        public abstract void DisplayAccountInfo();


    }

    class SavingsAccount : BankAccount
    {
        //constructor
        public SavingsAccount(string number, string name, float balance, float interest)
            :
            base(number, name, balance)
        {
            interestRate = interest;
        }
        // props
        private float interestRate;

        // methods

        // to deposit amount to bank account
        public override void Deposit(float amount)
        {
            accountBalance += amount + amount * interestRate / 100;
            Console.WriteLine("Funds have been deposited");
        }

        // to show account details to the user
        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Holder: {accountHolderName}");
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Balance: ${accountBalance}");
        }

    }
    class CheckingAccount : BankAccount
    {
        public CheckingAccount(string number, string name, float balance)
            :
            base(number, name, balance)
        { }

        // to withdraw money from the bank
        public override void Withdraw(float amount)
        {
            if (accountBalance < amount)
            {
                Console.WriteLine("Insufficient Balance");
                return;
            }
            accountBalance -= amount;
            Console.WriteLine("Thanks for using PuranaPay");

        }

        // to dispay account details to the user
        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Holder: {accountHolderName}");
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Balance: ${accountBalance}");
        }
    }
    class Bank
    {
        // props
        List<BankAccount> bankAccounts = new List<BankAccount>();

        //methods
        public void AddAccount(BankAccount account)
        {
            bankAccounts.Add(account);
            Console.WriteLine($"{account.getAccountName()}'s bank account has been added.");
        }

        public void DepositToAccount(string accountNumber, float amount)
        {
            foreach (BankAccount account in bankAccounts)
            {
                if (account.getAccountNumber() == accountNumber)
                {
                    account.Deposit(amount);
                }
            }
        }
        public void WithdrawFromAccount(string accountNumber, float amount)
        {
            foreach (BankAccount account in bankAccounts)
            {
                if (account.getAccountNumber() == accountNumber)
                {
                    account.Withdraw(amount);
                }
            }
        }
    }
}
