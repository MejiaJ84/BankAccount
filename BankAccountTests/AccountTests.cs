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
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount() // needs to be public to run
        {
            acc = new Account("Corvus Corax");
        }

        [TestMethod()]
        [DataRow(100)]
        [DataRow(.01)]
        [DataRow(1.99)]
        public void Deposit_PositiveAmount_AddToBalance(double depostiAmt)
        {
            

            acc.Deposit(depostiAmt);

            Assert.AreEqual(depostiAmt, acc.Balance);
        }

        [TestMethod]
        public void Deposit_PositiveAmount_ReturnUpdatedBalance()
        {
            /// AAA - Arrange Act Assert
            /// Arrange
            
            double depositAmt = 100;
            double expectedReturn = 100;

            /// Act
            double reutrnValue = acc.Deposit(depositAmt); // sends depositAmt to Deposit method in BankAccount class

            ///Assert
            Assert.AreEqual(expectedReturn, reutrnValue);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        public void Deposit_ZeroOrLess_ThrowsArgumentException(double invalidDepositAmt)
        {
            // Arrange
            // Uses CreateDefaultAccount
            
            // Assert => Act
            // () => : Wrapping test code in an anonymous function
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Deposit(invalidDepositAmt));
        }


        /// overdraw - ArgumentException
        
        [TestMethod]
        public void Withdraw_PositiveAmount_DecreasesBalance()
        {
            // Arrange
            double initialDeposit = 100;
            double withdrawalAmount = 50;
            double expectedBalance = initialDeposit - withdrawalAmount;

            // Act
            acc.Deposit(initialDeposit);
            acc.Withdraw(withdrawalAmount);

            double actualBalance = acc.Balance; // get balance after withdrawal

            //Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        [DataRow(100, 50)]
        [DataRow(100, .99)]
        public void Withdraw_PositiveAmount_ReturnsUpdatedBalance(double initialDeposit, 
                                                                    double withdrawalAmount)
        {
            // Arrange
            double expectedBalance = initialDeposit - withdrawalAmount;
            acc.Deposit(initialDeposit);

            // Act
            double returnBalance = acc.Withdraw(withdrawalAmount);

            // Assert
            Assert.AreEqual(expectedBalance, returnBalance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-.01)]
        [DataRow(-1000)]
        public void Withdraw_ZeroOrLess_ThrowsArgumentOutOfRangeException(double invalidWithdraw)
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => acc.Withdraw(invalidWithdraw));
        }

        [TestMethod]
        [DataRow(1000)]
        [DataRow(1)]
        public void Withdraw_OverDraw_ThrowsArgumentException(double withdrawAmount)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Withdraw(withdrawAmount));
        }

        [TestMethod]
        public void Owner_Null_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.Owner = null);
        }

        [TestMethod]
        public void Owner_WhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = String.Empty);
        }

        [TestMethod]
        [DataRow("Corvus")]
        [DataRow("Corcus Corax")]
        [DataRow("Corvus Corax hates h")]
        public void Owner_SetUpTo20Chars_Successfully(string ownerName)
        {
            acc.Owner = ownerName;
            Assert.AreEqual(ownerName, acc.Owner);
        }

        [TestMethod]
        [DataRow("Corvus 3rd")]
        [DataRow("Corvus Corax hates horus the traitor")]
        [DataRow("$%^")]
        public void Owner_InvalidName_ThrowsArgumentException(string ownerName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.Owner = ownerName);
        }

    }
}