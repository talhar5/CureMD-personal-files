using System;
namespace Assignment_2_BackAccountManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank MeezanBank = new Bank(); // creating  a bank
            Console.WriteLine();

            SavingsAccount talhaAccount = new SavingsAccount("PK1122", "Talha Razzaq", 1000, 1.7f); // creating a saving account
            CheckingAccount ashirAccount = new CheckingAccount("PK0105", "Muhammad Ashir", 2000); // creating a checking account
            Console.WriteLine();

            MeezanBank.AddAccount(talhaAccount); // adding accounts to the bank
            MeezanBank.AddAccount(ashirAccount);
            Console.WriteLine();

            // making some transactions
            MeezanBank.DepositToAccount("PK0105", 200);
            Console.WriteLine();
            MeezanBank.DepositToAccount("PK1122", 150);
            Console.WriteLine();
            MeezanBank.BankCharges("PK1122", 15);
            Console.WriteLine();
            MeezanBank.WithdrawFromAccount("PK0105", 9000);
            Console.WriteLine();
            MeezanBank.WithdrawFromAccount("PK1122", 90);
            Console.WriteLine();

            // displaying transaction history of talhaAccount
            talhaAccount.ShowTransactionHistory();
            Console.WriteLine();

            Console.WriteLine();
            Console.ReadKey();
        }
    }


}
