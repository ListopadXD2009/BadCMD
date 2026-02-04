using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static badcmd.Functions;

namespace badcmd
{
    internal static class Program
    {
        public static void Execute(string szCommand, out string szOutput, out string szError, string szDirectory = null)
        {
            Process process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c " + szCommand,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true,
                WorkingDirectory = szDirectory ?? Environment.CurrentDirectory
            };

            process.Start();

            szOutput = process.StandardOutput.ReadToEnd();
            szError = process.StandardError.ReadToEnd();

            process.WaitForExit();
        }

        // this is so fucking useless
        public static void ExecutePrompt()
        {
            Prompt();
        }

        [STAThread]
        public static void Main(string[] szArguments)
        {
            Console.WriteLine("BadCMD by SapphireTech/Aubrey, Licensed under MIT license.");
            Console.WriteLine("A bad open source attempt at making a command prompt for Windows\n");

            ExecutePrompt();
        }
    }
}
