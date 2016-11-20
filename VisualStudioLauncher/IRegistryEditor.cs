namespace VisualStudioLauncher.Core
{
    public interface IRegistryEditor
    {
        void Update(string registryKey, string name, string value);
    }
}