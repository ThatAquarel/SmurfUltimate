using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace SmurfUltimate
{
    class PortBind
    {
        //port 8080, 51329, 51340
        Socket port51329;
        Socket port51340;

        public void bindPorts()
        {
            killLsk();

            port51329 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            port51329.Bind(new IPEndPoint(IPAddress.Loopback, 51329));

            port51340 = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);
            port51340.Bind(new IPEndPoint(IPAddress.Loopback, 51340));

            startLsk();
        }

        public void closePorts()
        {
            if(port51329 != null && port51340 != null)
            {
                port51329.Close();
                port51340.Close();
            }
        }

        private void killLsk()
        {
            string targetProcessPath = @"c:\Program Files (x86)\LanSchool\student.exe";
            string targetProcessName = "student";

            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                if (process.ProcessName == targetProcessName &&
                    process.MainModule != null &&
                    string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    Debug.WriteLine("Killed");
                    process.Kill();
                }
            }
        }

        private void startLsk()
        {
            Process.Start("C:\\Program Files (x86)\\LanSchool\\student.exe");
            Debug.WriteLine("Started");
        }
    }
}
