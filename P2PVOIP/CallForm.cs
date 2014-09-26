using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace P2PVOIP
{
    public partial class CallForm : Form
    {
        Main main;
        delegate void SetTextCallback(string text);
        string myVoiceNodeAddress;
        CallData myCall;
        VoiceConnection voiceConnection;


        public CallForm(Main main, CallData myCall = null)
        {
            InitializeComponent();
            this.main = main;
            //this.CallingHashAddress = CallingHashAddress;
            this.myCall = myCall;

            if (myCall != null)
            {
                tbAddress.ReadOnly = true;
                tbAddress.Text = myCall.FromHashAddress;
                btCall.Text = "Pick up";
                lbStatus.Text = "Ring Ring..";
            }
        }

        private void btCall_Click(object sender, EventArgs e)
        {
            if (btCall.Text == "Pick up")
            {
                myVoiceNodeAddress = main.network.GetAvailableAddress();
                main.commands.CallAccept(myCall, myVoiceNodeAddress);

                voiceConnection = new VoiceConnection(this);
                voiceConnection.ConnectVoiceListener(myVoiceNodeAddress);
                voiceConnection.ConnectVoiceSender(myCall.VoiceNodeAddress);

                btCall.Text = "Hang up";
                lbStatus.Text = "Call Connected";
            }
            else if (btCall.Text == "Call")
            {
                main.commands.callForm = this;
                btCall.Text = "Hang up";

                Thread thread = new Thread(new ThreadStart(ProcessCallInvite));
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                //btCall.Text = "Call";
                //lbStatus.Text = "Call Ended";
                //tbAddress.ReadOnly = 
                //if (voiceConnection != null)
                //{
                //    voiceConnection.DisconnectVoiceListener();
                //    voiceConnection.DisconnectVoiceSender();
                //}
                this.Close();
            }
        }

        public void ProcessCallInvite()
        {
            myVoiceNodeAddress = main.network.GetAvailableAddress();
            main.commands.CallInvite(tbAddress.Text, myVoiceNodeAddress);
            SetStatusText("Sent call invite...");
        }

        public void ProcessCallAccept(PacketData data)
        {
            CallData myCall = new JavaScriptSerializer().Deserialize<CallData>(data.Data);
            this.myCall = myCall;

            voiceConnection = new VoiceConnection(this);
            voiceConnection.ConnectVoiceListener(myVoiceNodeAddress);
            voiceConnection.ConnectVoiceSender(myCall.VoiceNodeAddress);
            SetStatusText("Call Connected");
        }

        public void SetStatusText(string text)
        {
            if (this.lbStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetStatusText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                if (text != "Call ended")
                {
                    lbStatus.Text = text;
                }
                else
                {
                    lbStatus.Text = text;
                    btCall.Text = "Call";
                    tbAddress.ReadOnly = false;
                }

            }
        }
    }
}
