using System;

namespace VisualStudioLauncher.Application
{
    public interface ILauncher
    {
        void Run(TimeSpan timeOfDay);
    }
}