using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VisualStudioLauncher.Core.Tests
{
    [TestClass]
    public class LauncherConstructorTests
    {
        private Launcher sut;
        private Mock<IRegistryKeyProvider> mockRegistryProvider;
        private Mock<ITheme> mockTheme;
        private Mock<IProcess> mockProcess;
        private Mock<IRegistryEditor> mockRegEditor;

        [TestInitialize]
        public void Setup()
        {
            mockRegistryProvider = new Mock<IRegistryKeyProvider>();
            mockTheme = new Mock<ITheme>();
            mockProcess = new Mock<IProcess>();
            mockRegEditor = new Mock<IRegistryEditor>();

            sut = new Launcher(mockRegistryProvider.Object,
                               mockRegEditor.Object,
                               mockTheme.Object,
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
        public void ThemeIsNotNull() => Assert.IsNotNull(sut.Theme);

        [TestMethod]
        public void ThemeSetFromConstructor() => Assert.AreEqual(sut.Theme, mockTheme.Object);

        [TestMethod]
        public void ProcessIsNotNull() => Assert.IsNotNull(sut.Process);

        [TestMethod]
        public void ProcessSetFromConstructor() => Assert.AreEqual(sut.Process, mockProcess.Object);
    }
}