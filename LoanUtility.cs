using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank
{
    public class LoanUtility : ILoan
    {
        //decimal amount = 0m;
        public decimal LoanCalculation(decimal amount, decimal time)
        {
            decimal si = (amount * 5 * time)/100;
            amount = amount + si;
            return amount;
        }
    }
}
