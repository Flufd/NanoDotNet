using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RailBox.Models
{
    public struct RaiAmount
    {
        public RaiAmount(BigInteger amount, RaiAmountBase amountBase)
        {
            var exponent = BigInteger.Pow(10, (int)amountBase);
            Raw = amount * exponent;
        }

        public BigInteger Raw { get; private set; }
    }
}
