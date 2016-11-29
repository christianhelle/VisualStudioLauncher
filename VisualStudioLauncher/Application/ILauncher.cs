using System;

namespace VisualStudioLauncher.Application
{
    public interface ILauncher
    {
        void Run(string file = null, TimeSpan? timeOfDay = null);
    }
}