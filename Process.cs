using System;
using System.Diagnostics;

namespace SmurfUltimate
{
    internal class Process
    {
        private static string[] targetProcessesPath = { @"c:\Program Files (x86)\LanSchool\student.exe", @"c:\Program Files (x86)\LanSchool\LskHelper.exe", @"c:\Program Files (x86)\LanSchool\lskHlpr64.exe" };
        private static string[] targetProcessesName = { "student", "LskHelper", "lskHlpr64" };

        public static void killLsk()
        {
            for (int i = 0; i < targetProcessesPath.Length; i++)
            {
                string targetProcessPath = targetProcessesPath[i];
                string targetProcessName = targetProcessesName[i];

                System.Diagnostics.Process[] runningProcesses = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process process in runningProcesses)
                {
                    if (process.ProcessName == targetProcessName &&
                        process.MainModule != null &&
                        string.Compare(process.MainModule.FileName, targetProcessPath, StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        Debug.WriteLine("Killed " + targetProcessName);
                        process.Kill();
                    }
                }
            }
        }

        public static void startLsk()
        {
            for (int i = 0; i < targetProcessesPath.Length; i++)
            {
                string targetProcessPath = targetProcessesPath[i];
                string targetProcessName = targetProcessesName[i];

                System.Diagnostics.Process.Start(targetProcessPath.Replace("\\", "\\\\"));
                Debug.WriteLine("Started " + targetProcessName);
            }
        }
    }
}
