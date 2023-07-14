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

 
}
