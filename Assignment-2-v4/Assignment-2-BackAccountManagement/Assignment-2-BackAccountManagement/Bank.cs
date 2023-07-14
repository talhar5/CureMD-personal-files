using System;
using System.Collections.Generic;

namespace Assignment_2_BackAccountManagement
{
    // Aggregation: Bank class is the aggregate of BankAccount objects
    // this is not inheritance(is-a), this is association(has-a)
    // aggregation: weak bounding.
    class Bank
    {
        // Constructor
        public Bank()
        {
            bankAccounts = new Dictionary<string, BankAccount>();
            Console.WriteLine("A new Bank has been created.");
        }

        // props

        // Encapsulation: using private keyword to hide from other classes
        private Dictionary<string, BankAccount> bankAccounts;

        //methods
        public void AddAccount(BankAccount account)
        {
            bankAccounts.Add(account.AccountNumber, account);
            Console.WriteLine($"{account.AccountHolderName}'s bank account has been added to the Bank.");
        }

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
    }

}
