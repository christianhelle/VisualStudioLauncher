using VisualStudioLauncher.Platform;
using VisualStudioLauncher.Registry;

namespace VisualStudioLauncher.Application
{
    public interface IProcess
    {
        IRegistryKeyProvider RegistryKeyProvider { get; }
        IMostRecentlyUsedList MostRecentlyUsedList { get; }
        void Start(string file = null);
    }
}