using System;
//using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2PVOIP
{
    public partial class Main : Form
    {
        public string myNodeAddress = "";
        public string ipAddress;
        public int port;

        public Network network; 
        public Commands commands;

        public List<string> nodeList = new List<string>();
        public List<PacketStackItem> PacketStack = new List<PacketStackItem>();

        delegate void SetTextCallback(string text);


        public Main()
        {
            InitializeComponent();
        }

        public void OutputText(string output)
        {
            if (rtbOutput.Text != "")
            {
                rtbOutput.Text = rtbOutput.Text + Environment.NewLine + output;
            }
            else
            {
                rtbOutput.Text = output;
            }
        }

        public void InputText(string input)
        {
            if (rtbInput.Text != "")
            {
                rtbInput.Text = rtbInput.Text + Environment.NewLine + input;
            }
            else
            {
                rtbInput.Text = input;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            network = new Network(this);
            ipAddress = network.GetIPAddress();
            port = network.GetUnusedPort();
            myNodeAddress = port.ToString() + '@' + ipAddress;

            StripAddress.Text = myNodeAddress;
            commands = new Commands(this);

            //tbHashAddress.Text = commands.CreateMessageID();
            network.StartListeningForData();
            OutputText(myNodeAddress);
            MenuStrip.Enabled = false;
        }

        private void tbConnect_Click(object sender, EventArgs e)
        {
            string nodeAddress = tbNodeAddress.Text;
            string[] address = nodeAddress.Split('@');
            string ipAddress = address[1];
            int port = Convert.ToInt32(address[0]);

            commands.NodeExchangeInvite(ipAddress,port);
        }

        public void SetInputText(string text)
        {
            if (this.rtbInput.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetInputText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                InputText(text);
            }
        }

        public void AddNode(string nodeAddress)
        {
            nodeList.Add(nodeAddress);
            UpdateNodeList(nodeAddress);
        }

        public void UpdateNodeList(string text)
        {
            if (this.listBoxNodes.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(UpdateNodeList);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                listBoxNodes.Items.Add(text);
            }
        }

        public void SetOutputText(string text)
        {
            if (this.rtbInput.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetOutputText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                OutputText(text);
            }
        }

        private void listBoxNodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuStrip.Enabled = true;
        }

        private void btMessage_Click(object sender, EventArgs e)
        {
            MessageForm mf = new MessageForm(this,tbHashAddress.Text);
            mf.Show();
        }

        private void btCall_Click(object sender, EventArgs e)
        {
            CallForm call = new CallForm(this);
            call.Show();
        }

        public void ShowMessage(Message myMessage)
        {
            Application.Run(new MessageView(myMessage.FromHashAddress, myMessage.MessageBody));

        }

        public void ShowCallForm(CallForm callForm)
        {
            Application.Run(callForm);
        }
    }
}
