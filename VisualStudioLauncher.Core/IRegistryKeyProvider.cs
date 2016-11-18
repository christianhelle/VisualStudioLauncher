namespace VisualStudioLauncher.Core
{
    public interface IRegistryKeyProvider
    {
        string VisualStudioUserSettings { get; }
        string InstallationPath { get; }
    }
}