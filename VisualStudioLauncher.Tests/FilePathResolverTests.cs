using System;
using Moq;
using VisualStudioLauncher.Application;
using Xunit;

namespace VisualStudioLauncher.Tests
{
    public class FilePathResolverTests
    {
        private readonly Mock<IUserNotification> mockUserNotification;
        private readonly FilePathResolver sut;
        private readonly string filePath = Guid.NewGuid().ToString();

        public FilePathResolverTests()
        {
            mockUserNotification = new Mock<IUserNotification>();
            sut = new FilePathResolver(mockUserNotification.Object);
        }

        [Fact]
        public void ConstructorSetsUserNotification() => Assert.Equal(mockUserNotification.Object, sut.UserNotification);

        [Fact]
        public void ReturnsNullForNull() => Assert.Null(sut.Resolve(null));

        [Fact]
        public void PreffixesFilePathWithDoubleQuote() => Assert.StartsWith("\"", sut.Resolve(filePath));

        [Fact]
        public void SuffixesFilePathWithDoubleQuote() => Assert.EndsWith("\"", sut.Resolve(filePath));

        [Fact]
        public void NotifiesUserUponInvalidPath()
        {
            sut.Resolve(filePath);
            mockUserNotification.Verify(c => c.Prompt($"Invalid file path: {filePath}", "Error"));
        }
    }
}
