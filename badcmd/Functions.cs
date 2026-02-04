using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static badcmd.Program;

namespace badcmd
{
    internal static class Functions
    {
        public static void Prompt()
        {
            Console.Write("C:\\> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Prompt();
                return;
            }

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            Execute(input, out string output, out string error);

            if (!string.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine(output);
            }

            if (!string.IsNullOrWhiteSpace(error))
            {
                Console.WriteLine(error);
            }

            Prompt();
        }
    }
}
