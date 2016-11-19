namespace VisualStudioLauncher.Core
{
    public class Launcher : ILauncher
    {
        public Launcher(IRegistryKeyProvider registryKeys,
                        IRegistryEditor registryEditor,
                        ITheme theme,
                        IProcess process)
        {
            RegistryKeys = registryKeys;
            Theme = theme;
            Process = process;
            RegistryEditor = registryEditor;
        }

        public IRegistryKeyProvider RegistryKeys { get; }
        public ITheme Theme { get; }
        public IProcess Process { get; }
        public IRegistryEditor RegistryEditor { get; }

        public void Run()
        {
            RegistryEditor.Update(RegistryKeys.VisualStudioUserSettings,
                                  RegistryKeys.ThemeColorSettings,
                                  Theme.GetTheme());
            Process.Start();
        }
    }
}