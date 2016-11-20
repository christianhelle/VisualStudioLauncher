using Microsoft.Win32;

namespace VisualStudioLauncher.Registry
{
    public class RegistryEditor : IRegistryEditor
    {
        public void Update(string registryKey, string name, string value)
        {
            var subKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(registryKey, true);
            subKey?.SetValue(name, value, RegistryValueKind.String);
        }
    }
}