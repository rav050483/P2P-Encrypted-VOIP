using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PVOIP
{
    public class PacketStackItem
    {
        public PacketData Packet { get; set; }
        public DateTime Time { get; set; }
    }
}
