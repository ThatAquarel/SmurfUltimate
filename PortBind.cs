using System.Net.Sockets;

namespace SmurfUltimate
{
    internal class PortBind
    {
        //port 8080, 51329, 51340, 51227, 51274, 51474
        //    private Socket port51329;
        //    private Socket port51340;
        //    private Socket port51227;
        //    private Socket port51274;
        //    private Socket port51474;
        //    private Socket port51512;

        //    public void bindPorts()
        //    {
        //        Process.killLsk();

        //        port51329 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
        //        port51329.Bind(new IPEndPoint(IPAddress.Loopback, 51329));

        //        port51340 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
        //        port51340.Bind(new IPEndPoint(IPAddress.Loopback, 51340));

        //        port51227 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
        //        port51227.Bind(new IPEndPoint(IPAddress.Loopback, 51227));

        //        port51274 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
        //        port51274.Bind(new IPEndPoint(IPAddress.Loopback, 51274));

        //        port51474 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
        //        port51474.Bind(new IPEndPoint(IPAddress.Loopback, 51474));

        //        port51512 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
        //        port51512.Bind(new IPEndPoint(IPAddress.Loopback, 51512));

        //        Process.startLsk();
        //    }

        //    public void closePorts()
        //    {
        //        if (port51329 != null && port51340 != null && port51227 != null && port51274 != null && port51474 != null)
        //        {
        //            port51329.Close();
        //            port51340.Close();
        //            port51227.Close();
        //            port51274.Close();
        //            port51474.Close();
        //        }
        //    }
        //}

        private Socket[] sockets;

        public void BindPorts()
        {

        }

        public void ClosePorts()
        {

        }
    }
}