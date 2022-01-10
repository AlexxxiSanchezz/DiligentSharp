using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Locator;

partial class Build : NukeBuild
{
    static void TriggerAssemblyResolution() => _ = new ProjectCollection();

    Target FullCompile => CommonTarget
    (
        x => x.DependsOn(RegenerateBindings, Compile)
    );

    Target FullPack => CommonTarget
    (
        x => x.DependsOn(RegenerateBindings, Pack)
    );

    Target FullPushToNuGet => CommonTarget
    (
        x => x.DependsOn(FullPack, PushToNuGet)
    );
}
