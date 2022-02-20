using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace udp_socket
{
   
    public class UDPSocket
    {
        static Socket Socket;
        static IPAddress IPAddr;
        static IPEndPoint IPHost;

        public static bool CreateSocket(int port)
        {
            try
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                Socket.ReceiveTimeout = 1;

                String host_name = System.Net.Dns.GetHostName();
                IPHostEntry host = Dns.GetHostEntry(host_name);
                IPAddr = IPAddress.Any;

                IPHost = new IPEndPoint(IPAddr, port);
                Socket.Bind(IPHost);
                return true;
            }
            catch { return false; } 
        }

        public static bool Refresh(int port)
        {
            try
            {
                IPHost = new IPEndPoint(IPAddr, port);
                Socket.Bind(IPHost);
                return true;
            } 
            catch { return false; }
        }

        public static void SendUDP(byte[] data, string ipadr, int port)
        {
            UdpClient udpClient = new UdpClient(ipadr, port);
            udpClient.Send(data, data.Length);
        }

        public static void RemoteSendUDP(byte[] data, EndPoint endP)
        {
            Socket resock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            resock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            resock.SendTo(data, endP);
            resock.Dispose();
            resock.Close();
        }

        public static void CloseUDP()
        {
            Socket.Dispose();
            Socket.Close();
        }


    }
}
