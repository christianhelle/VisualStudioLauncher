using System;
using VisualStudioLauncher.Themes;
using Xunit;

namespace VisualStudioLauncher.Tests
{
    public class ColorThemeSettingsTests
    {
        private readonly ColorThemeSettings sut = new ColorThemeSettings();

        [Fact]
        public void ColorThemeSettingsForBlackThemeNotNull() => Assert.False(string.IsNullOrWhiteSpace(sut.GetValue(Theme.Black)));

        [Fact]
        public void ColorThemeSettingsForBlueThemeNotNull() => Assert.False(string.IsNullOrWhiteSpace(sut.GetValue(Theme.Blue)));

        [Fact]
        public void ColorThemeSettingsForWhiteThemeNotNull() => Assert.False(string.IsNullOrWhiteSpace(sut.GetValue(Theme.White)));

        [Fact]
        public void ColorThemeSettingsForNoneThrowsException() => Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetValue(Theme.None));
    }
}