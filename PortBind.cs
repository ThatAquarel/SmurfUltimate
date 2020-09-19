using System.Net;
using System.Net.Sockets;

namespace SmurfUltimate
{
    internal class PortBind
    {
        //port 8080, 51329, 51340, 51227, 51274, 51474
        // private Socket _port;
        //
        // public void BindPorts()
        // {
        //     Process.KillLsk();
        //
        //     _port = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
        //     _port.Bind(new IPEndPoint(IPAddress.Loopback, 56797));
        //
        //     Process.StartLsk();
        // }
        //
        // public void ClosePorts()
        // {
        //     _port?.Close();
        // }
        
        public void BindPorts()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = "/C copy /b Image1.jpg + Archive.rar Image2.jpg"
            };
            process.StartInfo = startInfo;
            process.Start();
        }
        
        public void ClosePorts()
        {
        
        }
    }
}