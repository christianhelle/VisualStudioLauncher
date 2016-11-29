using System;
using VisualStudioLauncher.Themes;
using Xunit;

namespace VisualStudioLauncher.Tests
{
    public class ThemeSelectorTests
    {
        [Fact]
        public void GetThemeReturnsBlackAtNight()
        {
            var sut = new ThemeSelector();
            var result = sut.GetTheme(TimeSpan.FromHours(18));
            Assert.Equal(Theme.Black, result);
        }

        [Fact]
        public void GetThemeReturnsBlueDuringTheDay()
        {
            var sut = new ThemeSelector();
            var result = sut.GetTheme(TimeSpan.FromHours(8));
            Assert.Equal(Theme.Blue, result);
        }
    }
}