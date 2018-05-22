using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Repository
{
    public class LoanRepository : ILoanRepository
    {
        private static IEnumerable<ILoan> _loans = new List<ILoan>()
                                                    {
                                                            new Loan(1, 50, 2000),
                                                            new Loan(2, 100, 1000)
                                                    };

        public ILoan GetLoan(int loanId)
        {
            return _loans.FirstOrDefault(x => x.LoanId == loanId);
        }

        public IEnumerable<ILoan> GetLoans()
        {
            return _loans;
        }
    }
}
