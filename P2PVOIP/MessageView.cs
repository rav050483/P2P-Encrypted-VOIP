using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2PVOIP
{
    public partial class MessageView : Form
    {
        public MessageView(string fromAddress, string message)
        {
            InitializeComponent();
            tbFromAddress.Text = fromAddress;
            rtbMessage.Text = message;
        }
    }
}
