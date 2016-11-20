using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VisualStudioLauncher.Application;
using VisualStudioLauncher.Registry;
using VisualStudioLauncher.Themes;

namespace VisualStudioLauncher.Tests
{
    [TestClass]
    public class LauncherRunTests
    {
        private Launcher sut;
        private Mock<IRegistryKeyProvider> mockRegistryProvider;
        private Mock<IThemeSelector> mockTheme;
        private Mock<IColorThemeSettings> mockThemeSettings;
        private Mock<IProcess> mockProcess;
        private Mock<IRegistryEditor> mockRegEditor;

        private readonly string regKey = Guid.NewGuid().ToString();
        private readonly string path = Guid.NewGuid().ToString();
        private readonly string name = Guid.NewGuid().ToString();
        private readonly string value = Guid.NewGuid().ToString();

        [TestInitialize]
        public void Setup()
        {
            mockRegistryProvider = new Mock<IRegistryKeyProvider>();
            mockRegistryProvider.SetupGet(p => p.VisualStudioUserSettings).Returns(regKey);
            mockRegistryProvider.SetupGet(p => p.InstallationPath).Returns(path);
            mockRegistryProvider.SetupGet(p => p.ThemeColorSettings).Returns(name);

            mockTheme = new Mock<IThemeSelector>();
            mockTheme.Setup(p => p.GetTheme(TimeSpan.FromHours(18))).Returns(Theme.Black);

            mockThemeSettings = new Mock<IColorThemeSettings>();
            mockThemeSettings.Setup(p => p.GetValue(Theme.Black)).Returns(value);

            mockProcess = new Mock<IProcess>();
            mockRegEditor = new Mock<IRegistryEditor>();

            sut = new Launcher(mockRegistryProvider.Object,
                               mockRegEditor.Object,
                               mockTheme.Object,
                               mockThemeSettings.Object,
                               mockProcess.Object);
            sut.Run(TimeSpan.FromHours(18));
        }

        [TestMethod]
        public void StartOnProcessCalledOnce() => mockProcess.Verify(process => process.Start(null), Times.Once);

        [TestMethod]
        public void RegistryEditorIsUpdated() => mockRegEditor.Verify(reg => reg.Update(regKey, name, value), Times.Once);
    }
}