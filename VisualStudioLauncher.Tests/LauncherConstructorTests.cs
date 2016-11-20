using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VisualStudioLauncher.Application;
using VisualStudioLauncher.Registry;
using VisualStudioLauncher.Themes;

namespace VisualStudioLauncher.Tests
{
    [TestClass]
    public class LauncherConstructorTests
    {
        private Launcher sut;
        private Mock<IRegistryKeyProvider> mockRegistryProvider;
        private Mock<IThemeSelector> mockThemeSelector;
        private Mock<IColorThemeSettings> mockThemeSettings;
        private Mock<IProcess> mockProcess;
        private Mock<IRegistryEditor> mockRegEditor;

        [TestInitialize]
        public void Setup()
        {
            mockRegistryProvider = new Mock<IRegistryKeyProvider>();
            mockThemeSelector = new Mock<IThemeSelector>();
            mockThemeSettings = new Mock<IColorThemeSettings>();
            mockProcess = new Mock<IProcess>();
            mockRegEditor = new Mock<IRegistryEditor>();

            sut = new Launcher(mockRegistryProvider.Object,
                               mockRegEditor.Object,
                               mockThemeSelector.Object,
                               mockThemeSettings.Object,
                               mockProcess.Object);
        }

        [TestMethod]
        public void RegistryProviderIsNotNull() => Assert.IsNotNull(sut.RegistryKeys);

        [TestMethod]
        public void RegistryProviderSetFromConstructor() => Assert.AreEqual(sut.RegistryKeys, mockRegistryProvider.Object);

        [TestMethod]
        public void RegistryEditorIsNotNull() => Assert.IsNotNull(sut.RegistryEditor);

        [TestMethod]
        public void RegistryEditorSetFromConstructor() => Assert.AreEqual(sut.RegistryEditor, mockRegEditor.Object);

        [TestMethod]
        public void ThemeSelectorIsNotNull() => Assert.IsNotNull(sut.ThemeSelector);

        [TestMethod]
        public void ThemeSelectorSetFromConstructor() => Assert.AreEqual(sut.ThemeSelector, mockThemeSelector.Object);

        [TestMethod]
        public void ColorThemeSettingsIsNotNull() => Assert.IsNotNull(sut.ColorThemeSettings);

        [TestMethod]
        public void ColorThemeSettingsSetFromConstructor() => Assert.AreEqual(sut.ColorThemeSettings, mockThemeSettings.Object);

        [TestMethod]
        public void ProcessIsNotNull() => Assert.IsNotNull(sut.Process);

        [TestMethod]
        public void ProcessSetFromConstructor() => Assert.AreEqual(sut.Process, mockProcess.Object);
    }
}