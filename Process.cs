using System;
using System.Diagnostics;

namespace SmurfUltimate
{
    internal static class Process
    {
        private static readonly string[] TargetProcessesPath = { @"c:\Program Files (x86)\LanSchool\student.exe", @"c:\Program Files (x86)\LanSchool\LskHelper.exe", @"c:\Program Files (x86)\LanSchool\lskHlpr64.exe" };
        private static readonly string[] TargetProcessesName = { "student", "LskHelper", "lskHlpr64" };

        public static void KillLsk()
        {
            for (int i = 0; i < TargetProcessesPath.Length; i++)
            {
                string targetProcessPath = TargetProcessesPath[i];
                string targetProcessName = TargetProcessesName[i];

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

        public static void StartLsk()
        {
            for (int i = 0; i < TargetProcessesPath.Length; i++)
            {
                string targetProcessPath = TargetProcessesPath[i];
                string targetProcessName = TargetProcessesName[i];

                System.Diagnostics.Process.Start(targetProcessPath.Replace("\\", "\\\\"));
                Debug.WriteLine("Started " + targetProcessName);
            }
        }
    }
}
