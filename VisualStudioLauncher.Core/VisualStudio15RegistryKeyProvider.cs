using System;
using Microsoft.Win32;

namespace VisualStudioLauncher.Core
{
    public class VisualStudio15RegistryKeyProvider : IRegistryKeyProvider
    {
        public string VisualStudioUserSettings { get; } 
            = @"SOFTWARE\Microsoft\VisualStudio\14.0\ApplicationPrivateSettings\Microsoft\VisualStudio";

        public string ThemeColorSettings { get; } = "ColorTheme";

        public string InstallationPath
        {
            get
            {
                string installationPath;
                if (Environment.Is64BitOperatingSystem)
                {
                    installationPath = (string)Registry.GetValue(
                        @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\14.0\",
                        "InstallDir",
                        null);
                }
                else
                {
                    installationPath = (string)Registry.GetValue(
                        @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\VisualStudio\14.0\",
                        "InstallDir",
                        null);
                }
                return installationPath;
            }
        }
    }
}