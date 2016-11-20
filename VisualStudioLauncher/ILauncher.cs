using System;

namespace VisualStudioLauncher.Core
{
    public interface ILauncher
    {
        void Run(TimeSpan timeOfDay);
    }
}