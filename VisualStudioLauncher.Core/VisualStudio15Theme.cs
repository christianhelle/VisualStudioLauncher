using System;

namespace VisualStudioLauncher.Core
{
    public class VisualStudio15Theme : ITheme
    {
        public string Blue { get; } = "0*System.String*a4d6a176-b948-4b29-8c66-53c97a1ed7d0";
        public string Black { get; } = "0*System.String*1ded0138-47ce-435e-84ef-9ec1f439b749";
        public string White { get; } = "0*System.String*de3dbbcd-f642-433c-8353-8f1df4370aba";
        
        public string GetTheme()
        {
            var time = DateTime.Now.TimeOfDay;
            if (time.TotalHours >= 18 || time.TotalHours <= 7)
                return Black;
            return Blue;
        }
    }
}