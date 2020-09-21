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
            for (var i = 0; i < TargetProcessesPath.Length; i++)
            {
                var targetProcessPath = TargetProcessesPath[i];
                var targetProcessName = TargetProcessesName[i];

                var runningProcesses = System.Diagnostics.Process.GetProcesses();
                foreach (var process in runningProcesses)
                {
                    if (process.ProcessName != targetProcessName || process.MainModule == null ||
                        string.Compare(process.MainModule.FileName, targetProcessPath,
                            StringComparison.InvariantCultureIgnoreCase) != 0) continue;
                    Debug.WriteLine("Killed " + targetProcessName);
                    process.Kill();
                }
            }
        }

        public static void StartLsk()
        {
            for (var i = 0; i < TargetProcessesPath.Length; i++)
            {
                var targetProcessPath = TargetProcessesPath[i];
                var targetProcessName = TargetProcessesName[i];

                System.Diagnostics.Process.Start(targetProcessPath.Replace("\\", "\\\\"));
                Debug.WriteLine("Started " + targetProcessName);
            }
        }
    }
}
