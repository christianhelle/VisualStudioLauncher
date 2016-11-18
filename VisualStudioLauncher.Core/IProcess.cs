using System.Diagnostics;
using System.IO;

namespace VisualStudioLauncher.Core
{
    public interface IProcess
    {
        IRegistryKeyProvider RegistryKeyProvider { get; }
        void Start(string solutionFile = null);
    }

    public class WindowsProcess : IProcess
    {
        public IRegistryKeyProvider RegistryKeyProvider { get; }

        public WindowsProcess(IRegistryKeyProvider registryKeyProvider)
        {
            RegistryKeyProvider = registryKeyProvider;
        }

        public void Start(string solutionFile = null)
        {
            var fileName = Path.Combine(RegistryKeyProvider.InstallationPath, "devenv.exe");
            Process.Start(fileName, solutionFile);
        }
    }
}