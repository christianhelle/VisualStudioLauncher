namespace VisualStudioLauncher.Core
{
    public interface IProcess
    {
        IRegistryKeyProvider RegistryKeyProvider { get; }
        void Start(string solutionFile = null);
    }
}