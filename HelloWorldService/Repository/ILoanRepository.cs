using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface ILoanRepository
    {
        IEnumerable<ILoan> GetLoans();
        ILoan GetLoan(int loanId);
    }
}
