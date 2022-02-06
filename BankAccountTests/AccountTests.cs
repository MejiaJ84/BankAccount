using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        [TestMethod()]
        public void Deposit_PositiveAmount_AddToBalance()
        {
            Account acc = new("C Corax");

            acc.Deposit(100);

            Assert.AreEqual(100, acc.Balance);
        }

        [TestMethod]
        public void Deposit_PositiveAmount_ReturnUpdatedBalance()
        {
            /// AAA - Arrange Act Assert
            /// Arrange
            Account acc = new("L Johnson");
            double depositAmt = 100;
            double expectedReturn = 100;

            /// Act
            double reutrnValue = acc.Deposit(depositAmt);

            ///Assert
            Assert.AreEqual(expectedReturn, reutrnValue);
        }
    }
}