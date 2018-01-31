using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RailBox
{
    /// <summary>
    /// Represents an amount of RaiBlocks
    /// </summary>
    public struct RaiAmount
    {
        /// <summary>
        /// Creates a RaiAmount of the specified amount and base unit
        /// </summary>
        /// <param name="amount">The numerical value of the amount</param>
        /// <param name="amountBase">The base unit of the amount</param>
        public RaiAmount(BigInteger amount, RaiAmountBase amountBase)
        {
            Raw = amount * BigInteger.Pow(10, (int)amountBase);
        }

        /// <summary>
        /// Creates a RaiAmount of the specified amount and base unit
        /// </summary>
        /// <param name="amount">The numerical value of the amount</param>
        /// <param name="amountBase">The base unit of the amount</param>
        public RaiAmount(long amount, RaiAmountBase amountBase)
        {
            Raw = amount * BigInteger.Pow(10, (int)amountBase);
        }


        /// <summary>
        /// The amount of Raw in the RaiAmount, this is the base amount for RaiBlocks
        /// </summary>
        public BigInteger Raw { get; private set; }

        /// <summary>
        /// Format the amount in the specified base unit
        /// </summary>
        /// <param name="raiAmountBase">The base unit to display the amount in</param>
        /// <returns></returns>
        public string ToString(RaiAmountBase raiAmountBase)
        {
            if(raiAmountBase == RaiAmountBase.raw)
            {
                return Raw.ToString();
            }

            // Get the string as raw
            var rawString = Raw.ToString();

            // How many zeros to add
            var zeros = new String('0', (int)raiAmountBase);

            var appended = zeros + rawString;
            
            // Move the decimal up by the base unit
            var withDecimal = appended.Substring(0, appended.Length - (int)raiAmountBase) + "." + appended.Substring(appended.Length - (int)raiAmountBase);

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
