using System.Diagnostics;
using System.IO;

namespace VisualStudioLauncher.Core
{
    public class VisualStudioProcess : IProcess
    {
        public IRegistryKeyProvider RegistryKeyProvider { get; }

        public VisualStudioProcess(IRegistryKeyProvider registryKeyProvider)
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