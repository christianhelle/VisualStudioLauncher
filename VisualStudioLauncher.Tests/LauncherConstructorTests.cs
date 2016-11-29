using Moq;
using VisualStudioLauncher.Application;
using VisualStudioLauncher.Registry;
using VisualStudioLauncher.Themes;
using Xunit;

namespace VisualStudioLauncher.Tests
{
    public class LauncherConstructorTests
    {
        private readonly Mock<IRegistryKeyProvider> mockRegistryProvider = new Mock<IRegistryKeyProvider>();
        private readonly Mock<IThemeSelector> mockThemeSelector = new Mock<IThemeSelector>();
        private readonly Mock<IColorThemeSettings> mockThemeSettings = new Mock<IColorThemeSettings>();
        private readonly Mock<IProcess> mockProcess = new Mock<IProcess>();
        private readonly Mock<IRegistryEditor> mockRegEditor = new Mock<IRegistryEditor>();
        private readonly Mock<IFilePathResolver> mockFilePathResolver = new Mock<IFilePathResolver>();
        private readonly Launcher sut;

        public LauncherConstructorTests()
        {
            sut = new Launcher(mockRegistryProvider.Object,
                               mockRegEditor.Object,
                               mockThemeSelector.Object,
                               mockThemeSettings.Object,
                               mockProcess.Object,
                               mockFilePathResolver.Object);
        }

        [Fact]
        public void RegistryProviderIsNotNull() => Assert.NotNull(sut.RegistryKeys);

        [Fact]
        public void RegistryProviderSetFromConstructor() => Assert.Equal(sut.RegistryKeys, mockRegistryProvider.Object);

        [Fact]
        public void RegistryEditorIsNotNull() => Assert.NotNull(sut.RegistryEditor);

        [Fact]
        public void RegistryEditorSetFromConstructor() => Assert.Equal(sut.RegistryEditor, mockRegEditor.Object);

        [Fact]
        public void ThemeSelectorIsNotNull() => Assert.NotNull(sut.ThemeSelector);

        [Fact]
        public void ThemeSelectorSetFromConstructor() => Assert.Equal(sut.ThemeSelector, mockThemeSelector.Object);

        [Fact]
        public void ColorThemeSettingsIsNotNull() => Assert.NotNull(sut.ColorThemeSettings);

        [Fact]
        public void ColorThemeSettingsSetFromConstructor() => Assert.Equal(sut.ColorThemeSettings, mockThemeSettings.Object);

        [Fact]
        public void ProcessIsNotNull() => Assert.NotNull(sut.Process);

        [Fact]
        public void ProcessSetFromConstructor() => Assert.Equal(sut.Process, mockProcess.Object);

        [Fact]
        public void FilePathResolverSetFromConstructor() => Assert.Equal(sut.FilePathResolver, mockFilePathResolver.Object);
    }
}