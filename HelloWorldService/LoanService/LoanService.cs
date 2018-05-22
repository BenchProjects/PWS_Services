using System;
using System.Collections.Generic;
using Domain;
using Repository;

namespace Services
{
    public class LoanService : ILoanService
    {
        private ILoanRepository _loanRepository;

        public LoanService(ILoanRepository repository)
        {
            _loanRepository = repository;
        }

        public ILoan GetLoan(int loanId)
        {
            return _loanRepository.GetLoan(loanId);
        }

        public IEnumerable<ILoan> GetLoans()
        {
            return _loanRepository.GetLoans();
        }
    }
}
