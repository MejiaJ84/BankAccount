using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    /// <summary>
    /// Represents a single customers bank account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Creates an account with a specific owner
        /// and a balance of 0
        /// </summary>
        /// <param name="accOwner">Full name of owner of the account</param>
        public Account(string accOwner)
        {
            Owner = accOwner;
        }

        /// <summary>
        /// Account owners full name
        /// </summary>
        public string Owner { get; set; }

        /// <summary>
        /// Amount of money in the account
        /// </summary>
        public double Balance { get; private set; }

        /// <summary>
        /// Add a specified amount of money to the account balance
        /// </summary>
        /// <param name="amt">Positive amount to add</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <returns>The new balance after deposit</returns>
        public double Deposit(double amt)
        {
            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Withdraws specified amount from the balance
        /// </summary>
        /// <exception cref="NotImplementedException">Positive amount to be withdrawn</exception>
        public void Withdraw()
        {
            throw new NotImplementedException();
        }
    }
}
