using System;
using VisualStudioLauncher.Core;

namespace VisualStudio15Launcher
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var launcher = new Launcher(new VisualStudio15RegistryProvider(), new VisualStudio15Theme());
            launcher.Run();
        }
    }
}