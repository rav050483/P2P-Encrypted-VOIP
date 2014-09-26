using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace P2PVOIP
{
    class CallManager
    {
        Main main;
        CallForm callForm;
        string toAddress;
        string myVoiceNodeAddress;
        string ClientVoiceNodeAddress;

        public CallManager(Main main, CallForm callForm, string toAddress)
        {
            this.main = main;
            this.callForm = callForm;
            this.toAddress = toAddress;
        }

        public void ProcessCall()
        {
            PacketData callPacket = CreateCallInvite();
            main.commands.AddPacketToStack(callPacket);
            //main.commands.callmanager = this;
            main.network.SendPacketToAllNodes(callPacket);

            callForm.SetStatusText("Start Call");
        }

        private PacketData CreateCallInvite()
        {
            int voicePort = main.network.GetUnusedPort();
            myVoiceNodeAddress = voicePort.ToString() + "@" + main.ipAddress;

            CallData callData = new CallData();
            callData.FromHashAddress = main.tbHashAddress.Text;
            callData.FromNodeAddress = main.myNodeAddress;
            callData.VoiceNodeAddress = myVoiceNodeAddress;

            string jsonCallData = new JavaScriptSerializer().Serialize(callData);

            PacketData packet = new PacketData();
            packet.Command = "CallInvite";
            packet.ToHashAddress = toAddress;
            packet.Data = jsonCallData;
            packet.PacketID = main.commands.CreatePacketID();

            return packet;
        }
    }
}
