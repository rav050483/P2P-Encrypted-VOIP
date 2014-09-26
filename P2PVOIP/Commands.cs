using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Security.Cryptography;


namespace P2PVOIP
{
    public class Commands
    {
        Main main;
        //CallManager callmanager;
        public CallForm callForm;

        public Commands(Main main)
        {
            this.main = main;
        }

        public void NodeExchangeInvite(string ipAddress, int port)
        {
            string toNodeAddress = port.ToString() + "@" + ipAddress;

            if (main.nodeList.Contains(toNodeAddress) == false)
            {
                PacketData packet = new PacketData();
                packet.Command = "NodeExchangeInvite";
                packet.FromNodeAddress = main.myNodeAddress;
                main.network.SendData(ipAddress, port, packet);
            }
        }

        public void NodeExchangeAccept(string ipAddress, int port, PacketData data)
        {
            PacketData packet = new PacketData();
            packet.Command = "NodeExchangeAccept";
            packet.FromNodeAddress = main.myNodeAddress;
            main.network.SendData(ipAddress, port, packet);
            main.AddNode(data.FromNodeAddress);
        }

        private void MessageReceipt(PacketData packetData, Message message)
        {
            string[] address = message.FromNodeAddress.Split('@');
            string ipAddress = address[1];
            int port = Convert.ToInt32(address[0]);

            PacketData packet = new PacketData();
            packet.Command = "MessageReceipt";
            packet.PacketID = packetData.PacketID;
            main.network.SendData(ipAddress, port, packet);

        }

        public void CallAccept(CallData callData, string myVoiceNodeAddress)
        {
            CallData myCallData = new CallData();
            myCallData.FromHashAddress = main.tbHashAddress.Text;
            myCallData.FromNodeAddress = main.myNodeAddress;
            myCallData.VoiceNodeAddress = myVoiceNodeAddress;

            string jsonCallData = new JavaScriptSerializer().Serialize(myCallData);

            PacketData packet = new PacketData();
            packet.Command = "CallAccept";
            packet.Data = jsonCallData;
            packet.PacketID = main.commands.CreatePacketID();

            string[] address = callData.FromNodeAddress.Split('@');
            string ipAddress = address[1];
            int port = Convert.ToInt32(address[0]);
            
            AddPacketToStack(packet);
            main.network.SendData(ipAddress, port, packet);
        }

        public void CallInvite(string toAddress, string myVoiceNodeAddress)
        {
            int voicePort = main.network.GetUnusedPort();

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

            AddPacketToStack(packet);
            main.network.SendPacketToAllNodes(packet);
        }

        private bool PacketInStack(PacketData data)
        {
            for (int x = 0; x < main.PacketStack.Count; x++)
            {
                PacketStackItem item = main.PacketStack[x];

                if (item.Packet.PacketID == data.PacketID)
                {
                    return true;
                }
            }

            AddPacketToStack(data);

            //Remove stack items older than 2 minutes
            main.PacketStack.RemoveAll(item => item.Time < DateTime.Now.AddMinutes(-2));

            return false;
        }

        private void ProcessCallAccept(PacketData data)
        {
            callForm.ProcessCallAccept(data);
        }

        private void ProcessCallInvite(PacketData data)
        {
            if (PacketInStack(data) == false)
            {
                if (data.ToHashAddress == main.tbHashAddress.Text)
                {
                    CallData myCall = new JavaScriptSerializer().Deserialize<CallData>(data.Data);
                    callForm = new CallForm(main, myCall);
                    main.ShowCallForm(callForm);
                }
                else
                {
                    main.network.SendPacketToAllNodes(data, data.FromNodeAddress);
                }
            }
        }

        private void ProcessReceivedMessage(PacketData data)
        {
            if (PacketInStack(data) == false)
            {
                if (data.ToHashAddress == main.tbHashAddress.Text)
                {
                    Message myMessage = new JavaScriptSerializer().Deserialize<Message>(data.Data);
                    MessageReceipt(data, myMessage);
                    main.ShowMessage(myMessage);
                }
                else
                {
                    main.network.SendPacketToAllNodes(data,data.FromNodeAddress);
                }
            }
        }

        public string CreatePacketID()
        {
            return SHA256_hash(main.myNodeAddress + main.commands.UnixTime());
        }

        public void AddPacketToStack(PacketData data)
        {
            PacketStackItem stackItem = new PacketStackItem();
            stackItem.Packet = data;
            stackItem.Time = DateTime.Now;
            main.PacketStack.Add(stackItem);
        }

        public String SHA256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

        public string UnixTime()
        {
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp.ToString();
        }

        public void StartProcessingData(PacketData data)
        {
            Thread thread = new Thread(() => ProcessReceivedData(data));
            thread.IsBackground = true;
            thread.Start();
        }

        public void ProcessReceivedData(PacketData data)
        {

            string[] address;
            string ipAddress = "";
            int port = 0;

            if (data.FromNodeAddress != null)
            {
                address = data.FromNodeAddress.Split('@');
                ipAddress = address[1];
                port = Convert.ToInt32(address[0]);
            }

            switch (data.Command)
            {
                case "NodeExchangeInvite":
                    NodeExchangeAccept(ipAddress, port, data);
                    break;
                case "NodeExchangeAccept":
                    main.nodeList.Add(data.FromNodeAddress);
                    main.UpdateNodeList(data.FromNodeAddress);
                    break;
                case "Message":
                    ProcessReceivedMessage(data);
                    break;
                case "MessageReceipt":
                    NodeExchangeInvite(ipAddress, port);
                    break;
                case "CallInvite":
                    ProcessCallInvite(data);
                    break;
                case "CallAccept":
                    ProcessCallAccept(data);

                    CallData myCall = new JavaScriptSerializer().Deserialize<CallData>(data.Data);
                    address = myCall.FromNodeAddress.Split('@');
                    ipAddress = address[1];
                    port = Convert.ToInt32(address[0]);
                    NodeExchangeInvite(ipAddress, port);

                    break;
            }

        }
    }
}
