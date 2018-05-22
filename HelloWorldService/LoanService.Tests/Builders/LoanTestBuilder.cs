using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tests.Builders
{
    public class LoanTestBuilder
    {
        private int _customerId;
        private int _outstandingAmount;
        private int _initialAmount;

        public LoanTestBuilder WithDefaults()
        {
            _customerId = 1;
            _outstandingAmount = 12;
            _initialAmount = 500;

            return this;
        }

        public LoanTestBuilder WithCustomerId(int customerId)
        {
            _customerId = customerId;

            return this;
        }

        public LoanTestBuilder WithOutstandingBalance(int outstandingBalance)
        {
            _outstandingAmount = outstandingBalance;

            return this;
        }

        public LoanTestBuilder WithInitialBalance(int intialAmount)
        {
            _initialAmount = intialAmount;

            return this;
        }

        public ILoan Build()
        {
            return new Loan(_customerId, _outstandingAmount, _initialAmount);
        }

    }
}
