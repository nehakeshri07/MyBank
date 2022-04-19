using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank
{
    public interface ILoan
    {
        public abstract decimal LoanCalculation(decimal amount, decimal time);
    }
}
