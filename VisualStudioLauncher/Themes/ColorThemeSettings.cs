using System;

namespace VisualStudioLauncher.Themes
{
    public class ColorThemeSettings : IColorThemeSettings
    {
        public const string Blue = "0*System.String*a4d6a176-b948-4b29-8c66-53c97a1ed7d0";
        public const string Black = "0*System.String*1ded0138-47ce-435e-84ef-9ec1f439b749";
        public const string White = "0*System.String*de3dbbcd-f642-433c-8353-8f1df4370aba";

        public string GetValue(Theme theme)
        {
            switch (theme)
            {
                case Theme.Blue: return Blue;
                case Theme.Black: return Black;
                case Theme.White: return White;
                default:
                    throw new ArgumentOutOfRangeException(nameof(theme), theme, null);
            }
        }
    }
}