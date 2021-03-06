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
        private string owner;

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
        public string Owner 
        {
            get { return owner; }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException(($"{nameof(Owner)} cannot be null"));
                }

                if (value.Trim() == string.Empty)
                {
                    throw new ArgumentException(($"{nameof(Owner)} must contain text"));
                }

                if (IsOwnerNameValid(value))
                {
                    owner = value;
                }
                else
                {
                    throw new ArgumentException($"{nameof(Owner)} can be up to 20 characters A-Z, and contain spaces.");
                }
            }
        
        }


        private bool IsOwnerNameValid(string ownerName)
        {
            char[] validChars = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
                             'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
                             'u', 'v', 'w', 'x', 'y', 'z'};
            ownerName = ownerName.ToLower();
            const int MaxNameLength = 20;
            if (ownerName.Length > MaxNameLength)
            {
                return false;
            }
            foreach (char letter in ownerName)
            {
                if (letter != ' ' && !validChars.Contains(letter))
                {
                    return false;
                }
            }
            return true;

        }

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
            if (amt <= 0)
            {
                // using nameof allows the variable name to be dynamic  
                throw new ArgumentOutOfRangeException($"{nameof(amt)} must be greater than 0");
            }

            Balance += amt;
            return Balance;
        }

        /// <summary>
        /// Withdraws specified amount from the balance
        /// </summary>
        /// <param name="amount"
        /// <returns>Returns updated balance after withdrawal</returns>
        public double Withdraw(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(amount)} must be greater than 0");
            }
            if (amount > Balance)
            {
                throw new ArgumentException($"{nameof(amount)} cannot be more than the available balance.");
            }
            return Balance -= amount;
        }


    }
}
