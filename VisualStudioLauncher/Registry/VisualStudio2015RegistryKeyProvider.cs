using System;

namespace VisualStudioLauncher.Registry
{
    public class VisualStudio2015RegistryKeyProvider : IRegistryKeyProvider
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
                    installationPath = (string)Microsoft.Win32.Registry.GetValue(
                        @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\VisualStudio\14.0\",
                        "InstallDir",
                        null);
                }
                else
                {
                    installationPath = (string)Microsoft.Win32.Registry.GetValue(
                        @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\VisualStudio\14.0\",
                        "InstallDir",
                        null);
                }
                return installationPath;
            }
        }
    }
}