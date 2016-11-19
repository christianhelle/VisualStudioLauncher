using System;
using VisualStudioLauncher.Core;

namespace VisualStudio15Launcher
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var launcher = new Launcher(new VisualStudio2015RegistryKeyProvider(),
                                        new RegistryEditor(),
                                        new ThemeSelector(),
                                        new ColorThemeSettings(),
                                        new VisualStudioProcess(new VisualStudio2015RegistryKeyProvider()));
            launcher.Run(DateTime.Now.TimeOfDay);
        }
    }
}