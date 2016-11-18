using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace VisualStudioLauncher.Core.Tests
{
    [TestClass]
    public class LauncherTests
    {
        private Launcher sut;
        private IRegistryKeyProvider registryKeyProvider;
        private ITheme theme;
        private IProcess process;

        [TestInitialize]
        public void Setup()
        {
            var mockRegistryProvider = new Mock<IRegistryKeyProvider>();
            registryKeyProvider = mockRegistryProvider.Object;

            var mockTheme = new Mock<ITheme>();
            theme = mockTheme.Object;

            var mockProcess = new Mock<IProcess>();
            process = mockProcess.Object;

            sut = new Launcher(registryKeyProvider, theme, process);
        }

        [TestMethod]
        public void ConstructorSetsRegistryProvider() => Assert.IsNotNull(sut.RegistryKeys);

        [TestMethod]
        public void ConstructorSetsTheme() => Assert.IsNotNull(sut.Theme);

        [TestMethod]
        public void ConstructorSetsProcess() => Assert.IsNotNull(sut.Process);
    }
}