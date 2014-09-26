using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace P2PVOIP
{
    public partial class MessageForm : Form
    {
        Main main;
        string myHashAddress;

        public MessageForm(Main main, string myHashAddress)
        {
            InitializeComponent();
            this.main = main;
            this.myHashAddress = myHashAddress;
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            MessageManager messageManager = new MessageManager(main, tbAddress.Text, rtbMessage.Text);
            messageManager.ProcessMessage();
            this.Close();
        }
    }
}
