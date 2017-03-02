using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Genymotion.Admin;
using Sprache;

namespace Cake.Genymotion.VirtualBox
{
    public class VirtualBoxRunner : VirtualBoxTool<VirtualBoxSettings>
    {
         private readonly ICakeEnvironment _environment;

        public VirtualBoxRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, VirtualBoxSettings settings) : base(fileSystem, environment, processRunner, tools, settings)
        {
            _environment = environment;
        }

     
        public IEnumerable<VirtualMachine> List()
        {
            var arguments = CreateArgumentBuilder(Settings).Append("list vms");

            var stdOutput = RunAndRedirectStandardOutput(Settings, arguments);

            return VirtualBoxListGrammer.Parse(stdOutput);
        }

     
    }
}
