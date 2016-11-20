using Microsoft.Win32;

namespace VisualStudioLauncher.Core
{
    public class RegistryEditor : IRegistryEditor
    {
        public void Update(string registryKey, string name, string value)
        {
            var subKey = Registry.CurrentUser.OpenSubKey(registryKey, true);
            subKey?.SetValue(name, value, RegistryValueKind.String);
        }
    }
}