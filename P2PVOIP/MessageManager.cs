using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace P2PVOIP
{
    class MessageManager
    {
        Main main;
        string myHashAddress;
        string toAddress;
        string messageBody;


        public MessageManager(Main main, string toAddress, string messageBody)
        {
            this.main = main;
            this.myHashAddress = main.tbHashAddress.Text;
            this.toAddress = toAddress;
            this.messageBody = messageBody;
        }

        public void ProcessMessage()
        {
            PacketData messagePacket = CreateMessageDataPacket();
            main.commands.AddPacketToStack(messagePacket);
            main.network.SendPacketToAllNodes(messagePacket);
        }

        public PacketData CreateMessageDataPacket()
        {
            Message myMessage = new Message();
            myMessage.FromHashAddress = myHashAddress;
            myMessage.FromNodeAddress = main.myNodeAddress;
            myMessage.MessageBody = messageBody;

            string jsonMessage = new JavaScriptSerializer().Serialize(myMessage);

            PacketData packet = new PacketData();
            packet.Command = "Message";
            packet.ToHashAddress = toAddress;
            packet.Data = jsonMessage;
            packet.PacketID = main.commands.CreatePacketID();

            return packet;
        }
    }
}
