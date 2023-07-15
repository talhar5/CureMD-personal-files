using System;
using System.Collections.Generic;

namespace Assignment_2_BackAccountManagement
{
    // --> Demonstrating Inheritance and Association
    // Aggregation: Bank class is the aggregate of BankAccount objects
    // bank has bank accounts
    // this is not inheritance(is-a), this is association(has-a)
    // aggregation: weak bounding.
    class Bank
    {
        // Constructor method
        // called when creating objects of this class
        // constructor cannot be private
        public Bank()
        {
            bankAccounts = new Dictionary<string, BankAccount>();
            Console.WriteLine("A new Bank has been created.");
        }

        // fields

        // Encapsulation: using private keyword to hide from other classes
        // --> Demonstrating Aggregation 
        // Bank has bank accounts
        private readonly Dictionary<string, BankAccount> bankAccounts;

        //methods
        // to add bankAccounts to the Bank
        public void AddAccount(BankAccount account)
        {
            bankAccounts.Add(account.AccountNumber, account);
            Console.WriteLine($"{account.AccountHolderName}'s bank account is added to the Bank.");
        }

        // to make transactions
        public void DepositToAccount(string accountNumber, float amount)
        {
            if (bankAccounts.ContainsKey(accountNumber))
            {
                bankAccounts[accountNumber].Deposit(amount);
            } else
            {
                Console.WriteLine("Invalid Account Number");
            }
        }
        public void WithdrawFromAccount(string accountNumber, float amount)
        {
            if (bankAccounts.ContainsKey(accountNumber))
            {
                bankAccounts[accountNumber].Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Invalid Account Number");
            }
        }
        public void BankCharges(string accountNumber, float amount)
        {
            if (bankAccounts.ContainsKey(accountNumber))
            {
                bankAccounts[accountNumber].BankCharges(amount);
            }
            else
            {
                Console.WriteLine("Invalid Account Number");
            }
        }
    }

}
