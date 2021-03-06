﻿using System;
using VisualStudioLauncher.Registry;
using VisualStudioLauncher.Themes;

namespace VisualStudioLauncher.Application
{
    public class Launcher : ILauncher
    {
        public Launcher(IRegistryKeyProvider registryKeys,
                        IRegistryEditor registryEditor,
                        IThemeSelector themeSelector,
                        IColorThemeSettings colorThemeSettings,
                        IProcess process,
                        IFilePathResolver filePathResolver)
        {
            RegistryKeys = registryKeys;
            ThemeSelector = themeSelector;
            ColorThemeSettings = colorThemeSettings;
            Process = process;
            FilePathResolver = filePathResolver;
            RegistryEditor = registryEditor;
        }

        public IRegistryKeyProvider RegistryKeys { get; }
        public IThemeSelector ThemeSelector { get; }
        public IColorThemeSettings ColorThemeSettings { get; set; }
        public IProcess Process { get; }
        public IFilePathResolver FilePathResolver { get; set; }
        public IRegistryEditor RegistryEditor { get; }

        public void Run(string file = null, TimeSpan? timeOfDay = null)
        {
            RegistryEditor.Update(RegistryKeys.VisualStudioUserSettings,
                                  RegistryKeys.ThemeColorSettings,
                                  ColorThemeSettings.GetValue(ThemeSelector.GetTheme(timeOfDay.GetValueOrDefault(DateTime.Now.TimeOfDay))));
            Process.Start(FilePathResolver.Resolve(file));
        }
    }
}