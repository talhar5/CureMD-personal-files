using System;

namespace Assignment_2_BackAccountManagement
{
    // --> Demonstrating Inheritance
    // 'is-a' relation
    // Inheriting BankAccount class and ITransaction interface
    // default access type: internal
    class CheckingAccount : BankAccount, ITransaction
    {
        // Constructor method
        // called when creating objects of this class
        // calling constructor of the base class demonstrating inheritance
        // constructor cannot be private
        public CheckingAccount(string number, string name, float balance)
            :
            base(number, name, balance)
        { }

        // to withdraw money from the bank
        // --> Demonstrating Polymorphism
        // Overriding: Dynamic Polymorphism: run-time polymorphism
        public override void Withdraw(float amount)
        {
            if (AccountBalance < amount)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                ExecuteTransaction(TransactionType.Withdraw, amount);
                PrintTransaction(TransactionType.Withdraw, amount);
                AddTransaction(TransactionType.Withdraw, amount);
            }

        }
        public override void Deposit(float amount)
        {
            ExecuteTransaction(TransactionType.Deposit, amount);
            PrintTransaction(TransactionType.Deposit, amount);
            AddTransaction(TransactionType.Deposit, amount);
        }

        public override void BankCharges(float amount)
        {
            if (AccountBalance < amount) {
                Console.WriteLine("Insufficient Balanace");
            }
            else
            {
                ExecuteTransaction(TransactionType.BankCharges, amount);
                PrintTransaction(TransactionType.BankCharges, amount);
                AddTransaction(TransactionType.BankCharges, amount);
            }
        }

        public override float CalculateInterest()
        {
            Console.WriteLine("Checking Account do not accrue interest");
            return 0;
        }

        // to dispay account details to the user
        public override void DisplayAccountInfo()
        {
            Console.WriteLine("--Account Information--");
            Console.WriteLine($"Account Holder Name: {AccountHolderName}");
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Balance: ${AccountBalance}");
        }

        // Demonstrating Polymorphism
        // implementing ITransaction interface (Realization)
        public void ExecuteTransaction(TransactionType type, float amount)
        {
            switch (type)
            {
                case TransactionType.Deposit:
                    ExecuteDeposit(amount);
                    break;
                case TransactionType.Withdraw:
                    ExecuteWithdraw(amount);
                    break;
                case TransactionType.BankCharges:
                    ExecuteBankCharges(amount);
                    break;
            }
        }
        // method to deduct bank charges
        private void ExecuteBankCharges(float amount)
        {
            AccountBalance -= amount;
        }
        private void ExecuteDeposit(float amount)
        {
            AccountBalance += amount;
        }
        private void ExecuteWithdraw(float amount)
        {
            AccountBalance += amount;
        }

        // PrintTransaction calls the appropriate Receipt method depending upon the transaction type
        public void PrintTransaction(TransactionType type, float amount)
        {
            switch (type)
            {
                case TransactionType.Deposit:
                    DepositReceipt(amount);
                    break;
                case TransactionType.Withdraw:
                    WithdrawReceipt(amount);
                    break;
                case TransactionType.BankCharges:
                    BankChargesReceipt(amount);
                    break;
            }
        }

        // methods to print different types of receipts
        private void DepositReceipt(float amount)
        {
            Console.WriteLine("--Transaction Details--\n");
            Console.WriteLine("Transaction Type: Money Deposit");
            Console.WriteLine("Amount credited: ${0}", amount);
            Console.WriteLine("Current Balance: ${0}\n", AccountBalance);
        }
        private void WithdrawReceipt(float amount)
        {
            Console.WriteLine("--Transaction Details--\n");
            Console.WriteLine("Transaction Type: Money Withdrawal");
            Console.WriteLine("Amount debited: ${0}", amount);
            Console.WriteLine("Current Balance: ${0}\n", AccountBalance);
        }
        private void BankChargesReceipt(float amount)
        {
            Console.WriteLine("--Transaction Details--\n");
            Console.WriteLine("Transaction Type: Bank Charges");
            Console.WriteLine("Amount debited: ${0}", amount);
            Console.WriteLine("Current Balance: ${0}\n", AccountBalance);
        }
    }

}
