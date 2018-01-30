using System;
using System.Collections.Generic;
using System.Text;

namespace RailBox
{
    public enum RaiAmountBase
    {
        /// <summary>
        /// The Base unit of a RaiBlocks amount
        /// </summary>
        raw = 0,

        /// <summary>
        /// Giga xrb, one of these is 10^33 raw or 1 Billion xrb
        /// </summary>
        Gxrb = 33,

        /// <summary>
        /// Mega xrb, one of these is 10^30 raw or 1 Million xrb
        /// This is often the unit used on exchanges
        /// </summary>
        Mxrb = 30,

        /// <summary>
        /// Kilo xrb, one of these is 10^27 raw or 1000 xrb
        /// </summary>
        kxrb = 27,

        /// <summary>
        /// An xrb, one of these is 10^24 raw
        /// </summary>
        xrb = 24,

        /// <summary>
        /// Milli xrb, one of these is 10^21 raw or 0.001 xrb
        /// </summary>
        mxrb = 21,

        /// <summary>
        /// Micro xrb, one of these is 10^18 raw or 0.000001 xrb
        /// </summary>
        uxrb = 18
    }
}
