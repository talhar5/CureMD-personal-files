using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_BackAccountManagement
{
    class Transaction
    {
        public Transaction(string type, float amount)
        {
            this.type = type;
            this.amount = amount;
        }
        private string type;
        private float amount;
    }
}
