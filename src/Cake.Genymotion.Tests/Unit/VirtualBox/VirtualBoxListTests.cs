using Cake.Core;
using Cake.Genymotion;
using Cake.Genymotion.Tests.Fixtures.Admin;
using Cake.Testing;
using FluentAssertions;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Cake.Genymotion.Tests.Unit.VirtualBox
{
    public class VirtualBoxListTests
    {
        [Fact]
        public void Should_Add_Virtual_Box_List_Argument()
        {
            // Given
            var fixture = new VirtualBoxListFixture();

            // When
            var result = fixture.Run();

            // Then
            result.Args.Should().Be("list vms");
        }

    

        [Fact]
        public void Should_Return_Correct_VirtualBox_Details()
        {
            // Given
            var fixture = new VirtualBoxListFixture();

            // When
            var result = fixture.Run();

            // Then
            fixture.ToolResult.Should().HaveCount(9);

            fixture.ToolResult.First().UUID.Should().Be("b7c55d9c-cc49-4b28-91ec-ea79933a55a1");
            fixture.ToolResult.First().Name.Should().Be("Nexus 5 (Lollipop)");
            
            fixture.ToolResult.Last().UUID.Should().Be("a26e023c-dd7e-4351-a08e-b693fa7a911b");
            fixture.ToolResult.Last().Name.Should().Be("Google Nexus 5 - 6.0.0 - API 23 - 1080x1920");
        }

       

        [Theory]
        [InlineData(@"C:\Program Files\Oracle\VirtualBox\VBoxManage.exe", @"C:/Program Files/Oracle/VirtualBox/VBoxManage.exe")]
        [InlineData(@"\Applications\VirtualBox.app\Contents\MacOS\VBoxManage", "/Applications/VirtualBox.app/Contents/MacOS/VBoxManage")]
        public void Should_Use_VirtualBox_Runner_From_Tool_Path_If_Provided(string toolPath, string expected)
        {
            // Given
            var fixture = new GenymotionAdminListFixture { Settings = { ToolPath = toolPath } };
            fixture.GivenSettingsToolPathExist();

            // When
            var result = fixture.Run();

            // Then
            result.Path.FullPath.Should().Be(expected);
        }
    }
}