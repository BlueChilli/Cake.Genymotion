using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Genymotion.Admin;

namespace Cake.Genymotion.VirtualBox
{
    internal class VirtualBoxListGrammer
    {
        public static IEnumerable<VirtualMachine> Parse(string stdOutput)
        {
            var lines = stdOutput.SplitLines();
            var machines = new List<VirtualMachine>();
             var regexUUID = new Regex(@"(?<=\{).+?(?=\})");
             var regexName = new Regex(String.Format(@"(?<=\{0}).+?(?=\{1})",  "\"", "\""));

            foreach (var line in lines)
            {
                var uuidMatch = regexUUID.Match(line);
                var nameMatch = regexName.Match(line);

                if (uuidMatch.Success && nameMatch.Success)
                {
                    machines.Add(new VirtualMachine()
                    {
                        UUID = uuidMatch.Value,
                        Name = nameMatch.Value
                    });
                    
                }
            }

            return machines;
        }
    }
}
