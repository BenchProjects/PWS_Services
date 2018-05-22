using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldService.Models
{
    public class LoanViewModel
    {
        public LoanViewModel()
        {

        }

        public LoanViewModel(ILoan loan)
        {
            LoanId = loan.LoanId;
            OutstandingAmount = loan.OutstandingBalance;
            InitialAmount = loan.InitialAmount;
        }

        public int LoanId { get; private set; }
        public int OutstandingAmount { get; private set; }
        public int InitialAmount { get; private set; }
    }
}
