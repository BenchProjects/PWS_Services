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
    public class LoanServiceTests_GetById
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
        public void GetLoan_CallsRepository()
        {
            //Arrange
            ILoan loan = GetDefaultLoan();

            _mockTestRepository.Setup(x => x.GetLoan(It.IsAny<int>())).Returns(loan);

            //Act
            var actual = _loanService.GetLoan(5);

            //Assert
            _mockTestRepository.Verify(x => x.GetLoan(It.IsAny<int>()));
        }

        [TestMethod]
        public void GetLoan_ReturnsMatchedLoan()
        {
            //Arrange
            ILoan loan = GetDefaultLoan();

            _mockTestRepository.Setup(x => x.GetLoan(6)).Returns(loan);

            //Act
            var actual = _loanService.GetLoan(6);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(loan.LoanId, actual.LoanId);
            Assert.AreEqual(loan.InitialAmount, actual.InitialAmount);
            Assert.AreEqual(loan.OutstandingBalance, actual.OutstandingBalance);
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
