using System;

namespace VisualStudioLauncher.Core
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