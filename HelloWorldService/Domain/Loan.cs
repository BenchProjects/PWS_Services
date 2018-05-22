using System;

namespace Domain
{
    public class Loan : ILoan
    {
        public Loan(int loanId, int outstandingBalance, int initialAmount)
        {
            LoanId = loanId;
            OutstandingBalance = outstandingBalance;
            InitialAmount = initialAmount;
        }

        public int LoanId { get; }

        public int OutstandingBalance { get; }

        public int InitialAmount { get; }
    }
}
