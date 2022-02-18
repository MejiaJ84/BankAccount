using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public static class Validator
    {
        public static bool IsWithinRange(double minVal, double maxVal, double testVal)
        {
            if (testVal >= minVal && testVal <= maxVal)
            {
                return true;
            }
            return false;
        }
    }
}
