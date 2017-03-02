using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Sprache;

namespace Cake.Genymotion.Admin
{
    internal sealed class GenymotionPlayerRunner : GenymotionTool<GenymotionAdminSettings>
    {
        private readonly ICakeEnvironment _environment;

        public GenymotionPlayerRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IToolLocator tools, GenymotionAdminSettings settings) : base(fileSystem, environment, processRunner, tools, settings)
        {
            _environment = environment;
        }


        public void Start(string deviceIdentifier)
        {
            var builder = CreateArgumentBuilder(Settings);

            if (_environment.Platform.IsUnix())
            {
                builder.Prepend("open -a");
            }

            var arguments = builder.Append($"--args --vm-name").AppendQuotedUnlessNullWhitespaceOrEmpty(deviceIdentifier);


            Run(Settings, arguments);
        }

        public void Stop()
        {
            var builder = CreateArgumentBuilder(Settings);

            if (_environment.Platform.IsUnix())
            {
                builder.Prepend("killall");

               var arguments = builder;

               Run(Settings, arguments);
            }

          
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
             return new[]
            {
                "player",
                "player.exe"
            };
        }

          /// <summary>
        ///     Gets alternative file paths which the tool may exist in
        /// </summary>
        /// <returns>The alternative locations for the tool.</returns>
        protected override IEnumerable<FilePath> GetAlternativeToolPaths(GenymotionAdminSettings settings)
        {
            return new FilePath[]
            {
                new FilePath(@"C:\Program Files\Genymobile\Genymotion\player.exe"),
                new FilePath(@"/Applications/Genymotion.app/Contents/MacOS/player.app")
            };
        }

    }
}