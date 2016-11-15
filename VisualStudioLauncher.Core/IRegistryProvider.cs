namespace VisualStudioLauncher.Core
{
    public interface IRegistryProvider
    {
        string VisualStudioUserSettings { get; }
        string InstallationPath { get; }
    }
}