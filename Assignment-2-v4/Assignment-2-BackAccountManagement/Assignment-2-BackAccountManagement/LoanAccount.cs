using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_BackAccountManagement
{
    class LoanAccount : BankAccount, ITransaction
    {
        public LoanAccount(string accountNumber, string accountName, float accountBalance) : base(accountNumber, accountName, accountBalance) { }


        public override void DisplayAccountInfo()
        {
            Console.WriteLine("loan account info");
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
    }

}
