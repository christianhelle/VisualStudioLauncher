namespace VisualStudioLauncher.Registry
{
    public interface IRegistryEditor
    {
        void Update(string registryKey, string name, string value);
    }
}