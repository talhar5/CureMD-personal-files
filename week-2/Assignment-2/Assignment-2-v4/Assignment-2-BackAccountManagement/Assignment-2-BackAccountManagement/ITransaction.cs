using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_BackAccountManagement
{
    // creating interfaces that will be  implemented in the implement classes
    // this is a concept of Abstraction in OOP.
    // to hide implementation details

    public interface ITransaction
    {
        void ExecuteTransaction(decimal amount);
        void PrintTransaction();
    }
}
