using System;
using Moq;
using VisualStudioLauncher.Application;
using VisualStudioLauncher.Registry;
using VisualStudioLauncher.Themes;
using Xunit;

namespace VisualStudioLauncher.Tests
{
    public class LauncherRunTests
    {
        private readonly Mock<IProcess> mockProcess;
        private readonly Mock<IRegistryEditor> mockRegEditor;

        private readonly string regKey = Guid.NewGuid().ToString();
        private readonly string path = Guid.NewGuid().ToString();
        private readonly string name = Guid.NewGuid().ToString();
        private readonly string value = Guid.NewGuid().ToString();

        public LauncherRunTests()
        {
            var mockRegistryProvider = new Mock<IRegistryKeyProvider>();
            mockRegistryProvider.SetupGet(p => p.VisualStudioUserSettings).Returns(regKey);
            mockRegistryProvider.SetupGet(p => p.InstallationPath).Returns(path);
            mockRegistryProvider.SetupGet(p => p.ThemeColorSettings).Returns(name);

            var mockTheme = new Mock<IThemeSelector>();
            mockTheme.Setup(p => p.GetTheme(TimeSpan.FromHours(18))).Returns(Theme.Black);

            var mockThemeSettings = new Mock<IColorThemeSettings>();
            mockThemeSettings.Setup(p => p.GetValue(Theme.Black)).Returns(value);

            mockProcess = new Mock<IProcess>();
            mockRegEditor = new Mock<IRegistryEditor>();

            var launcher = new Launcher(mockRegistryProvider.Object,
                                        mockRegEditor.Object,
                                        mockTheme.Object,
                                        mockThemeSettings.Object,
                                        mockProcess.Object);
            launcher.Run(TimeSpan.FromHours(18));
        }

        [Fact]
        public void RegistryEditorIsUpdated() => mockRegEditor.Verify(reg => reg.Update(regKey, name, value), Times.Once);

        [Fact]
        public void StartOnProcessCalledOnce() => mockProcess.Verify(process => process.Start(null), Times.Once);
    }
}