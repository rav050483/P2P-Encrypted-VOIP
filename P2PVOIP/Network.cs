using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Web.Script.Serialization;

namespace P2PVOIP
{
    public class Network
    {
        Main main;
        bool listenData = false;

        public Network(Main main)
        {
            this.main = main;
        }
        public string GetIPAddress()
        {
            IPHostEntry ipList;
            ipList = Dns.GetHostEntry(Dns.GetHostName());

            for (int x = ipList.AddressList.Count()-1; x >0; x--)
            {
                IPAddress address = ipList.AddressList[x];
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }

            return null;
        }

        public int GetUnusedPort()
        {
            var listener = new TcpListener(IPAddress.Any, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }

        public string GetAvailableAddress()
        {
            return GetUnusedPort().ToString() + "@" + GetIPAddress();
        }

        public void StartListeningForData()
        {
            listenData = true;
            Thread thread = new Thread(new ThreadStart(ListenForData));
            thread.IsBackground = true;
            thread.Start();
        }

        public void SendPacketToAllNodes(PacketData data, string exceptionNode = null)
        {
            for (int x = 0; x < main.nodeList.Count; x++)
            {
                string nodeAddress = main.nodeList[x];

                if (nodeAddress != exceptionNode)
                {
                    string[] address = nodeAddress.Split('@');
                    string ipAddress = address[1];
                    int port = Convert.ToInt32(address[0]);

                    SendData(ipAddress, port, data);
                }
            }
        }

        public void SendData(string ipAddress, int port, PacketData packet)
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                IPAddress send_to_iPAddress = IPAddress.Parse(ipAddress);
                IPEndPoint sending_end_point = new IPEndPoint(send_to_iPAddress, port);

                packet.FromNodeAddress = main.myNodeAddress;
                string data = new JavaScriptSerializer().Serialize(packet);

                byte[] send_buffer = Encoding.ASCII.GetBytes(data);
                socket.SendTo(send_buffer, sending_end_point);

                main.SetOutputText("ToNode:" + port.ToString() + "@" + ipAddress + " " + data);
            }
            catch (Exception ex)
            {
                main.SetOutputText(ex.Message);
            }
        }

        public void ListenForData()
        {
            UdpClient listener = new UdpClient(main.port);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, main.port);
            string received_data = "";
            byte[] receive_byte_array;

            try
            {
                while (listenData)
                {
                    receive_byte_array = listener.Receive(ref groupEP);
                    received_data = Encoding.ASCII.GetString(receive_byte_array, 0, receive_byte_array.Length);

                    main.SetInputText(received_data);

                    PacketData data = new JavaScriptSerializer().Deserialize<PacketData>(received_data);
                    main.commands.StartProcessingData(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            listener.Close();
        }
    }
}
