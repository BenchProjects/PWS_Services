using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    [TestClass]
    public class LoanTests
    {
        [TestMethod]
        public void LoanConstructorInitialisesAllProperties()
        {
            //Arrange
            int expectedLoanId = 7;
            int expectedOutstandingBalance = 300;
            int expectedInitialAmount = 500;

            //Act
            var actual = new Loan(expectedLoanId, expectedOutstandingBalance, expectedInitialAmount);

            //Assert
            Assert.AreEqual(expectedLoanId, actual.LoanId);
            Assert.AreEqual(expectedOutstandingBalance, actual.OutstandingBalance);
            Assert.AreEqual(expectedInitialAmount, actual.InitialAmount);


        }
    }
}
