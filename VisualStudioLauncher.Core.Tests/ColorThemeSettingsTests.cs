using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VisualStudioLauncher.Core.Tests
{
    [TestClass]
    public class ColorThemeSettingsTests
    {
        private readonly ColorThemeSettings sut = new ColorThemeSettings();

        [TestMethod]
        public void ColorThemeSettingsForBlackThemeNotNull() => Assert.IsFalse(string.IsNullOrWhiteSpace(sut.GetValue(Theme.Black)));

        [TestMethod]
        public void ColorThemeSettingsForBlueThemeNotNull() => Assert.IsFalse(string.IsNullOrWhiteSpace(sut.GetValue(Theme.Blue)));

        [TestMethod]
        public void ColorThemeSettingsForWhiteThemeNotNull() => Assert.IsFalse(string.IsNullOrWhiteSpace(sut.GetValue(Theme.White)));

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ColorThemeSettingsForNoneThrowsException() => sut.GetValue(Theme.None);
    }
}