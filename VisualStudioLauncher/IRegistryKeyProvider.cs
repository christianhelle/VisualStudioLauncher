namespace VisualStudioLauncher.Core
{
    public interface IRegistryKeyProvider
    {
        string VisualStudioUserSettings { get; }
        string ThemeColorSettings { get; }
        string InstallationPath { get; }
    }
}