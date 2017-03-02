using System;
using Cake.Genymotion;
using Cake.Testing.Fixtures;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cake.Core.IO;
using Cake.Genymotion.Admin;
using Cake.Genymotion.VirtualBox;

namespace Cake.Genymotion.Tests.Fixtures.Admin
{
    internal sealed class VirtualBoxListFixture : VirtualBoxFixture<VirtualBoxSettings>
    {
        public VirtualBoxListFixture()
        {
            var standardOutput = File.ReadAllLines(@"..\..\Fixtures\VirtualBox\VirtualMachineList.txt");
            ProcessRunner.Process.SetStandardOutput(standardOutput);
        }

        public IEnumerable<VirtualMachine> ToolResult { get; set; }

        protected override void RunTool()
        {
            var adminRunner = new VirtualBoxRunner(FileSystem, Environment, ProcessRunner, Tools, Settings);
            ToolResult = adminRunner.List();
        }
    }
}