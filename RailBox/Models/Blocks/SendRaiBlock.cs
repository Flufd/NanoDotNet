using System;
using System.Collections.Generic;
using System.Text;

namespace RailBox
{
    public class SendRaiBlock : RaiBlock
    {
        public string Previous { get; set; }
        public string Destination { get; set; }
        public string Work { get; set; }
        public string Balance { get; set; }
        public string Signature { get; set; }
    }
}
