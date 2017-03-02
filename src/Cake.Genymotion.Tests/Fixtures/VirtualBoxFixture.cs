using Cake.Core.IO;
using Cake.Genymotion.VirtualBox;
using Cake.Testing.Fixtures;

namespace Cake.Genymotion.Tests.Fixtures
{
    internal abstract class VirtualBoxFixture<TSettings> : ToolFixture<TSettings, ToolFixtureResult>
        where TSettings : VirtualBoxSettings, new()
    {
    
        protected VirtualBoxFixture() : base("VBoxManage")
        {

        }

        protected override ToolFixtureResult CreateResult(FilePath path, ProcessSettings process)
        {
            return new ToolFixtureResult(path, process);
        }
    }
}