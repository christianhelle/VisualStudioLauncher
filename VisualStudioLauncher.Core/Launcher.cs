using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace VisualStudioLauncher.Core
{
    public class Launcher
    {
        public IRegistryKeyProvider RegistryKeys { get; }
        public ITheme Theme { get; }
        public IProcess Process { get; }

        public Launcher(IRegistryKeyProvider registryKeys, ITheme theme, IProcess process)
        {
            RegistryKeys = registryKeys;
            Theme = theme;
            Process = process;
        }

        public void Run()
        {
            var regKey = RegistryKeys.VisualStudioUserSettings + @"\ApplicationPrivateSettings\Microsoft\VisualStudio";
            var subKey = Registry.CurrentUser.OpenSubKey(regKey, true);
            subKey?.SetValue("ColorTheme", Theme.GetTheme(), RegistryValueKind.String);
            Process.Start();
        }
    }
}
