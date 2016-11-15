using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;

namespace VisualStudioLauncher.Core
{
    public class Launcher
    {
        public IRegistryProvider RegistryProvider { get; }
        public ITheme Theme { get; }

        public Launcher(IRegistryProvider registryProvider, ITheme theme)
        {
            RegistryProvider = registryProvider;
            Theme = theme;
        }

        public void Run()
        {
            var regKey = RegistryProvider.VisualStudioUserSettings + @"\ApplicationPrivateSettings\Microsoft\VisualStudio";
            var subKey = Registry.CurrentUser.OpenSubKey(regKey, true);
            subKey?.SetValue("ColorTheme", GetTheme(), RegistryValueKind.String);
            Process.Start(Path.Combine(RegistryProvider.InstallationPath, "devenv.exe"));
        }

        private string GetTheme()
        {
            var time = DateTime.Now.TimeOfDay;
            if (time.TotalHours >= 18 || time.TotalHours <= 7)
                return Theme.Black;
            return Theme.Blue;
        }
    }
}
