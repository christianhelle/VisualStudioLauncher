using System;
using VisualStudioLauncher.Application;
using VisualStudioLauncher.Registry;
using VisualStudioLauncher.Themes;

namespace VisualStudioLauncher
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var registryKeyProvider = new VisualStudio2015RegistryKeyProvider();
            var launcher = new Launcher(registryKeyProvider,
                                        new RegistryEditor(),
                                        new ThemeSelector(),
                                        new ColorThemeSettings(),
                                        new VisualStudioProcess(registryKeyProvider));
            launcher.Run(DateTime.Now.TimeOfDay);
        }
    }
}