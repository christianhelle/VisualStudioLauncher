﻿using System;
using System.Linq;
using VisualStudioLauncher.Application;
using VisualStudioLauncher.Registry;
using VisualStudioLauncher.Themes;

namespace VisualStudioLauncher
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            var registryKeyProvider = new VisualStudio2015RegistryKeyProvider();
            var launcher = new Launcher(registryKeyProvider,
                                        new RegistryEditor(),
                                        new ThemeSelector(),
                                        new ColorThemeSettings(),
                                        new VisualStudioProcess(registryKeyProvider));
            launcher.Run(args.FirstOrDefault());
        }
    }
}