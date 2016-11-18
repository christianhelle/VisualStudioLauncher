﻿using System;
using VisualStudioLauncher.Core;

namespace VisualStudio15Launcher
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var registryKeys = new VisualStudio15RegistryKeyProvider();
            var process = new WindowsProcess(registryKeys);
            var theme = new VisualStudio15Theme();
            var launcher = new Launcher(registryKeys, theme, process);
            launcher.Run();
        }
    }
}