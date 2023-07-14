using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_BackAccountManagement
{
    class CheckingAccount : BankAccount, ITransaction
    {
        public CheckingAccount(string number, string name, float balance)
            :
            base(number, name, balance)
        { }

        // to withdraw money from the bank
        public override void Withdraw(float amount)
        {
            if (AccountBalance < amount)
            {
                Console.WriteLine("Insufficient Balance");
                return;
            }
            AccountBalance -= amount;
            Console.WriteLine("Thanks for using Meezan");
            GetTransactions();

        }

        public override float CalculateInterest()
        {
            // to be implemented
            return 0;
        }



        // to dispay account details to the user
        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: ${AccountBalance}");
        }

        // implementing ITransaction
        public void ExecuteTransaction(decimal amount)
        {
            // to be implemented
        }
        public void PrintTransaction()
        {
            //to be implemented
        }
    }

}
