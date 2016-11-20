using System;

namespace VisualStudioLauncher.Themes
{
    public interface IThemeSelector
    {
        Theme GetTheme(TimeSpan timeOfDay);
    }
}