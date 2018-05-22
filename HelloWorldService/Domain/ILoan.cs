using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface ILoan
    {
        int LoanId { get; }
        int OutstandingBalance { get; }

        int InitialAmount { get; }

      
    }
}
