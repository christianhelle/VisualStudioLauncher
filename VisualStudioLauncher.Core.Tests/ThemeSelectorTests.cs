using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VisualStudioLauncher.Core.Tests
{
    [TestClass]
    public class ThemeSelectorTests
    {
        [TestMethod]
        public void GetThemeReturnsBlackAtNight()
        {
            var sut = new ThemeSelector();
            var result = sut.GetTheme(TimeSpan.FromHours(18));
            Assert.AreEqual(Theme.Black, result);
        }

        [TestMethod]
        public void GetThemeReturnsBlueDuringTheDay()
        {
            var sut = new ThemeSelector();
            var result = sut.GetTheme(TimeSpan.FromHours(8));
            Assert.AreEqual(Theme.Blue, result);
        }
    }
}