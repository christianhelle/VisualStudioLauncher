using VisualStudioLauncher.Registry;

namespace VisualStudioLauncher.Application
{
    public interface IProcess
    {
        IRegistryKeyProvider RegistryKeyProvider { get; }
        void Start(string solutionFile = null);
    }
}