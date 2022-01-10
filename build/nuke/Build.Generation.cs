using System.IO;
using Nuke.Common;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using Silk.NET.BuildTools;
using Newtonsoft.Json;

partial class Build
{
    Target RegenerateBindings => CommonTarget
    (
        x => x.After(Clean)
            .DependsOn(Restore)
            .Executes
            (
                () =>
                {
                    Generator.Run(JsonConvert.DeserializeObject<Config>(File.ReadAllText(Path.Combine(RootDirectory, "generator.json"))));
                }
            )
    );

}