using System;
using System.Collections.Generic;
using System.Text;

namespace NanoDotNet
{
    public enum AmountBase
    {
        /// <summary>
        /// The Base unit of a Nano amount
        /// </summary>
        raw = 0,

        /// <summary>
        /// Giga xrb, one of these is 10^33 raw or 1 Billion xrb
        /// </summary>
        Gxrb = 33,

        /// <summary>
        /// Giga rai, one of these is 10^33 raw or 1 Billion xrb
        /// </summary>
        Grai = 33,

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
        /// Kilo rai, one of these is 10^27 raw or 1000 rai
        /// </summary>
        krai = 27,

        /// <summary>
        /// An xrb, one of these is 10^24 raw
        /// </summary>
        xrb = 24,

        /// <summary>
        /// One rai, one of these is 10^24 raw
        /// </summary>
        rai = xrb,

        /// <summary>
        /// Milli xrb, one of these is 10^21 raw or 0.001 xrb
        /// </summary>
        mxrb = 21,

        /// <summary>
        /// Milli rai, one of these is 10^21 raw or 0.001 rai
        /// </summary>
        mrai = 21,

        /// <summary>
        /// Micro xrb, one of these is 10^18 raw or 0.000001 xrb
        /// </summary>
        uxrb = 18,

        /// <summary>
        /// Micro rai, one of these is 10^18 raw or 0.000001 rai
        /// </summary>
        urai = 18,

        /// <summary>
        /// One Nano, this is equal to one million xrb
        /// </summary>
        Nano = Mxrb,

        /// <summary>
        /// One Mrai, this is equal to one milion xrb
        /// </summary>
        Mrai = Mxrb,

        /// <summary>
        /// One Raiblock, this is equal to one million xrb
        /// </summary>
        RaiBlock = Mxrb
    }
}
