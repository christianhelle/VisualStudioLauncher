using System;

namespace VisualStudioLauncher.Themes
{
    public class ThemeSelector : IThemeSelector
    {
        public Theme GetTheme(TimeSpan timeOfDay)
        {
            if (timeOfDay.TotalHours >= 18 || timeOfDay.TotalHours <= 7)
                return Theme.Black;
            return Theme.Blue;
        }
    }
}