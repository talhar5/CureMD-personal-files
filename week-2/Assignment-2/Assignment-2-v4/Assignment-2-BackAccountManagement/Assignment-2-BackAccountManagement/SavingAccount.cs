using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_BackAccountManagement
{
    class SavingsAccount : BankAccount, ITransaction
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
            AccountBalance += amount + amount * interestRate / 100;
            Console.WriteLine("Funds have been deposited");
            AddTransaction("Deposit", amount);
        }

        public override float CalculateInterest()
        {
            return 0;
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



        // to show account details to the user
        public override void DisplayAccountInfo()
        {
            Console.WriteLine($"Account Holder: {AccountHolderName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: ${AccountBalance}");
        }

    }

}
