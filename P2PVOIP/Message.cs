using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2PVOIP
{
    public class Message
    {
        public string FromHashAddress { get; set; }
        public string FromNodeAddress { get; set; }
        public string MessageBody { get; set; }
    }
}
