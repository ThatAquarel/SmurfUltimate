using System.Net;
using System.Net.Sockets;

namespace SmurfUltimate
{
    class PacketBlock
    {
        //port 8080, 51329, 51340
        Socket port51329;
        Socket port51340;

        public void bindPorts()
        {
            port51329 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            port51329.Bind(new IPEndPoint(IPAddress.Loopback, 51329));

            port51340 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            port51340.Bind(new IPEndPoint(IPAddress.Loopback, 51340));
        }

        public void closePorts()
        {
            if(port51329 != null && port51340 != null)
            {
                port51329.Close();
                port51340.Close();
            }
        }
    }
}
