using System.Diagnostics;
using System.IO;
using VisualStudioLauncher.Platform;
using VisualStudioLauncher.Registry;

namespace VisualStudioLauncher.Application
{
    public class VisualStudioProcess : IProcess
    {
        public IRegistryKeyProvider RegistryKeyProvider { get; }
        public IMostRecentlyUsedList MostRecentlyUsedList { get; }

        public VisualStudioProcess(IRegistryKeyProvider registryKeyProvider, IMostRecentlyUsedList mostRecentlyUsedList)
        {
            RegistryKeyProvider = registryKeyProvider;
            MostRecentlyUsedList = mostRecentlyUsedList;
        }

        public void Start(string file = null)
        {
            var fileName = Path.Combine(RegistryKeyProvider.InstallationPath, "devenv.exe");
            Process.Start(fileName, file);

            if (string.IsNullOrWhiteSpace(file) || !File.Exists(file))
                return;

            var fullPath = Path.GetFullPath(file);
            MostRecentlyUsedList.AddToRecentlyUsedDocs(fullPath);
        }
    }
}