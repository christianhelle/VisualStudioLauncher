namespace VisualStudioLauncher.Tests
{
    public class VisualStudioSelectorTests
    {
        private const string ExampleSolution = @"
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 14
VisualStudioVersion = 14.0.25420.1
MinimumVisualStudioVersion = 10.0.40219.1
Project(\""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\"") = \""VisualStudioLauncher\"", \""VisualStudioLauncher\VisualStudioLauncher.csproj\"", \""{5DE2684C-CBAF-4A4F-8BC9-D10AD0F8CB31}\""
EndProject
Project(\""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}\"") = \""VisualStudioLauncher.Tests\"", \""VisualStudioLauncher.Tests\VisualStudioLauncher.Tests.csproj\"", \""{6C2996E1-1E39-4CE3-BD50-3F4DC464C8B1}\""
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug | Any CPU
        Release|Any CPU = Release | Any CPU
      EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{5DE2684C-CBAF-4A4F-8BC9-D10AD0F8CB31
    }.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        { 5DE2684C - CBAF - 4A4F - 8BC9 - D10AD0F8CB31}.Debug|Any CPU.Build.0 = Debug|Any CPU
        { 5DE2684C - CBAF - 4A4F - 8BC9 - D10AD0F8CB31}.Release|Any CPU.ActiveCfg = Release|Any CPU
        { 5DE2684C - CBAF - 4A4F - 8BC9 - D10AD0F8CB31}.Release|Any CPU.Build.0 = Release|Any CPU
        { 6C2996E1 - 1E39 - 4CE3 - BD50 - 3F4DC464C8B1}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        { 6C2996E1 - 1E39 - 4CE3 - BD50 - 3F4DC464C8B1}.Debug|Any CPU.Build.0 = Debug|Any CPU
        { 6C2996E1 - 1E39 - 4CE3 - BD50 - 3F4DC464C8B1}.Release|Any CPU.ActiveCfg = Release|Any CPU
        { 6C2996E1 - 1E39 - 4CE3 - BD50 - 3F4DC464C8B1}.Release|Any CPU.Build.0 = Release|Any CPU
EndGlobalSection
GlobalSection(SolutionProperties) = preSolution
HideSolutionNode = FALSE
    EndGlobalSection
EndGlobal
";
    }
}