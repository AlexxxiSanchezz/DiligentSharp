using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Tools.DotNet;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

partial class Build
{
    Target Pack => CommonTarget
    (
        x => x.DependsOn(Restore)
            .After(Clean, RegenerateBindings)
            .Produces("build/output_packages/*.nupkg")
            .Executes
            (
                () => DotNetPack
                (
                    s => s.SetProject(Solution)
                        .SetConfiguration(Configuration)
                        .EnableNoRestore()
                        .SetProperties(ProcessedMsbuildProperties)
                )
            )
    );
}