using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface ILoanService
    {
        IEnumerable<ILoan> GetLoans();

        ILoan GetLoan(int loanId);
    }
}
