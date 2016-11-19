using System;

namespace VisualStudioLauncher.Core
{
    public interface IThemeSelector
    {
        Theme GetTheme(TimeSpan timeOfDay);
    }
}