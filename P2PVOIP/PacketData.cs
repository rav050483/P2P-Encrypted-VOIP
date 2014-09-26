using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PVOIP
{
    public class PacketData
    {
        public string Command { get; set; }
        public string FromNodeAddress { get; set; }
        public string PacketID { get; set; }
        public string ToHashAddress { get; set; }
        public string Data { get; set; }
    }
}
