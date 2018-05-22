using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository;
using Service.Tests.Builders;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Tests
{
    [TestClass]
    public class LoanServiceTests_Get
    {
        private Mock<ILoanRepository> _mockTestRepository;
        private ILoanService _loanService;

        [TestInitialize]
        public void Setup()
        {
            _mockTestRepository = new Mock<ILoanRepository>();
            _loanService = new LoanService(_mockTestRepository.Object);
        }

        [TestMethod]
        public void GetLoans_CallsRepository()
        {
            //Arrange
            ILoan loan = GetDefaultLoan();

            _mockTestRepository.Setup(x => x.GetLoans()).Returns(new List<ILoan>() { loan });

            //Act
            var actual = _loanService.GetLoans();

            //Assert
            _mockTestRepository.Verify(x => x.GetLoans());
        }

        [TestMethod]
        public void GetLoans_ReturnsTwoLoans()
        {
            //Arrange
            ILoan loan = GetDefaultLoan();
            ILoan loan2 = GetDefaultLoan();
            var expectedLoansReturned = 2;

            _mockTestRepository.Setup(x => x.GetLoans()).Returns(new List<ILoan>() { loan, loan2 });

            //Act
            var actual = _loanService.GetLoans();

            //Assert
            Assert.AreEqual(expectedLoansReturned, actual.Count());
        }

        [TestMethod]
        public void GetLoans_ReturnsLoansWithCorrectDetails()
        {
            //Arrange
            ILoan loan = GetLoan(5, 500, 1000);
            ILoan loan2 = GetLoan(7, 10, 359);
            var expectedLoansReturned = 2;

            _mockTestRepository.Setup(x => x.GetLoans()).Returns(new List<ILoan>() { loan, loan2 });

            //Act
            var actual = _loanService.GetLoans();

            //Assert
            Assert.AreEqual(loan.LoanId, actual.ElementAt(0).LoanId);
            Assert.AreEqual(loan.InitialAmount, actual.ElementAt(0).InitialAmount);
            Assert.AreEqual(loan.OutstandingBalance, actual.ElementAt(0).OutstandingBalance);
            Assert.AreEqual(loan2.LoanId, actual.ElementAt(1).LoanId);
            Assert.AreEqual(loan2.InitialAmount, actual.ElementAt(1).InitialAmount);
            Assert.AreEqual(loan2.OutstandingBalance, actual.ElementAt(1).OutstandingBalance);
        }

        private ILoan GetDefaultLoan()
        {
            return new LoanTestBuilder().WithDefaults().Build();
        }

        private ILoan GetLoan(int customerId, int outstandingBalance, int initialAmount)
        {
            return new LoanTestBuilder()
                .WithCustomerId(customerId)
                .WithOutstandingBalance(outstandingBalance)
                .WithInitialBalance(initialAmount)
                .Build();
        }
    }
}
