using Domain;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldService
{
    public static class DependencyInjector
    {
        public static void InjectDependencies(this IServiceCollection collection){
            collection.AddTransient<ILoanRepository, LoanRepository>();
            collection.AddTransient<IServiceCollection, ServiceCollection>();
            collection.AddTransient<ILoan, Loan>();
            collection.AddTransient<ILoanService, LoanService>();
        }
    }
}
