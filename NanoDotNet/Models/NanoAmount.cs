using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NanoDotNet
{
    /// <summary>
    /// Represents an amount of Nano currency
    /// </summary>
    public struct NanoAmount
    {
        /// <summary>
        /// Creates a <see cref="NanoAmount"/> of the specified amount and base unit
        /// </summary>
        /// <param name="amount">The numerical value of the amount</param>
        /// <param name="amountBase">The base unit of the amount</param>
        public NanoAmount(BigInteger amount, AmountBase amountBase)
        {
            Raw = amount * BigInteger.Pow(10, (int)amountBase);
        }

        /// <summary>
        /// Creates a <see cref="NanoAmount"/> of the specified amount and base unit
        /// </summary>
        /// <param name="amount">The numerical value of the amount</param>
        /// <param name="amountBase">The base unit of the amount</param>
        public NanoAmount(long amount, AmountBase amountBase)
        {
            Raw = amount * BigInteger.Pow(10, (int)amountBase);
        }


        /// <summary>
        /// The amount of Raw in the <see cref="NanoAmount"/>, this is the base amount for Nano
        /// </summary>
        public BigInteger Raw { get; private set; }

        /// <summary>
        /// Format the amount in the specified base unit
        /// </summary>
        /// <param name="amountBase">The base unit to display the amount in</param>
        /// <returns></returns>
        public string ToString(AmountBase amountBase)
        {
            if(amountBase == AmountBase.raw)
            {
                return Raw.ToString();
            }

            // Get the string as raw
            var rawString = Raw.ToString();

            // How many zeros to add
            var zeros = new String('0', (int)amountBase);

            var appended = zeros + rawString;
            
            // Move the decimal up by the base unit
            var withDecimal = appended.Substring(0, appended.Length - (int)amountBase) + "." + appended.Substring(appended.Length - (int)amountBase);

            // Trim off leaing zeros and trailing zeros and decimal points
            var trimmed = withDecimal.TrimStart('0').TrimEnd('0').TrimEnd('.');
            if(trimmed.Length == 0)
            {
                return "0";
            }

            if(trimmed[0] == '.')
            {
                return "0" + trimmed;
            }

            return trimmed;
        }
    }
}
