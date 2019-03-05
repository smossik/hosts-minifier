using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hostsfile_minifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application start");
            if (File.Exists(args[0]))
            {
                int modNumber = 0;
                if (args.Length > 1) int.TryParse(args[1], out modNumber);
                modNumber = modNumber > 0 ? modNumber : 11;
                Console.WriteLine($"Hostsfile minifier, accessing file: {args[0]}, modNumber: {modNumber}");
                List<string> text = File.ReadAllLines(args[0]).ToList();
                int lineCountBefore = text.Count;
                text.RemoveAll(x => !x.StartsWith("0.0.0.0")
                                    && !x.StartsWith("127.0.0.1")
                                    && !x.StartsWith("255.255.255.255")
                                    && !x.StartsWith("::1")
                                    && !x.StartsWith("f"));
                List<string> output = new List<string>();
                string tempString = string.Empty;
                int firstEntry = text.FindIndex(x => x.StartsWith("0.0.0.0") && !x.StartsWith("0.0.0.0 0.0.0.0"));
                var firstItems = text.GetRange(0, firstEntry);
                text.RemoveRange(0, firstEntry);
                for (var x = 0; x < text.Count; x++)
                {
                    if (x % modNumber > 0 && x > 0)
                    {
                        tempString += text[x].Remove(text[x].IndexOf("0.0.0.0", StringComparison.Ordinal), "0.0.0.0".Length);
                    }

                    else if (x % modNumber == 0)
                    {
                        if (tempString.Any())
                        { output.Add(tempString); }
                        tempString = string.Empty;
                        tempString += text[x];
                    }
                }

                firstItems.AddRange(output);
                Console.WriteLine($"Hostsfile minified, from {lineCountBefore} to {firstItems.Count}");
                Console.WriteLine($"Writing to output_hosts.txt");
                File.WriteAllLines($"output_hosts.txt", firstItems);
            }
            else
            {
                Console.WriteLine("Supplied arguments not valid: " + args[0]);
            }
        }
    }
}
