using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using NAudio.Wave;
using System.Net.Sockets;
using System.Net;

namespace P2PVOIP
{
    class VoiceConnection
    {
        CallForm callForm;
        UdpClient udpSender;
        UdpClient udpListener;
        BufferedWaveProvider waveProvider;
        bool connected = false;

        public VoiceConnection(CallForm callForm)
        {
            this.callForm = callForm;
        }

        public void ConnectVoiceSender(string sendAddress)
        {
            string[] address = sendAddress.Split('@');
            string ipAddress = address[1];
            int port = Convert.ToInt32(address[0]);

            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), int.Parse(port.ToString()));
            //WaveIn waveIn = new WaveIn();
            WaveInEvent waveIn = new WaveInEvent();
            waveIn.BufferMilliseconds = 20;
            waveIn.NumberOfBuffers = 2;
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(8000, 16, 1);
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();

            udpSender = new UdpClient();

            udpSender.Connect(endPoint);
        }

        public void DisconnectVoiceSender()
        {
            udpSender.Close();
        }

        public void DisconnectVoiceListener()
        {
            udpListener.Close();
        }

        public void ConnectVoiceListener(string sendAddress)
        {
            string[] address = sendAddress.Split('@');
            string ipAddress = address[1];
            int port = Convert.ToInt32(address[0]);

            udpListener = new UdpClient();
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), int.Parse(port.ToString()));
            udpListener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpListener.Client.Bind(endPoint);

            IWavePlayer waveOut = new WaveOut();
            waveProvider = new BufferedWaveProvider(new NAudio.Wave.WaveFormat(8000, 16, 1));
            waveProvider.DiscardOnBufferOverflow = true;
            waveOut.Init(waveProvider);
            waveOut.Play();

            connected = true;

            Thread oThread = new Thread(() => ListenVoice(endPoint));
            oThread.IsBackground = true;
            oThread.Start();
        }

        private void ListenVoice(IPEndPoint endPoint)
        {
            while (connected)
            {
                byte[] b = udpListener.Receive(ref endPoint);
                byte[] decoded = Decode(b, 0, b.Length);
                waveProvider.AddSamples(decoded, 0, decoded.Length);
            }
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] encoded = Encode(e.Buffer, 0, e.BytesRecorded);
            udpSender.Send(encoded, encoded.Length);
        }

        public byte[] Encode(byte[] data, int offset, int length)
        {
            byte[] encoded = new byte[length / 2];
            int outIndex = 0;
            for (int n = 0; n < length; n += 2)
            {
                encoded[outIndex++] = NAudio.Codecs.ALawEncoder.LinearToALawSample(BitConverter.ToInt16(data, offset + n));
            }

            return encoded;
        }

        public byte[] Decode(byte[] data, int offset, int length)
        {
            byte[] decoded = new byte[length * 2];
            int outIndex = 0;
            for (int n = 0; n < length; n++)
            {
                short decodedSample = NAudio.Codecs.ALawDecoder.ALawToLinearSample(data[n + offset]);
                decoded[outIndex++] = (byte)(decodedSample & 0xFF);
                decoded[outIndex++] = (byte)(decodedSample >> 8);
            }
            return decoded;
        }
    }
}
