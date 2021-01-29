using System;
using Microsoft.Extensions.Configuration;
using Moq;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Xunit;

namespace Nevo.Api.Test
{
    public class BootstrapperTest
    {
        private readonly Mock<IConfiguration> _configuration;

        public BootstrapperTest() => _configuration = new();

        [Fact(DisplayName = "Bootstrapper creates valid container.")]
        public void Bootstrap_CreatesValidContainer()
        {
            // Arrange
            Container container = new();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            Mock<IConfigurationSection> configSection = new();
            configSection.SetupGet(x => x[It.IsAny<string>()]).Returns("");

            _configuration
                .Setup(x => x.GetSection(It.IsAny<string>()))
                .Returns(configSection.Object);

            // Act
            Bootstrapper.Bootstrap(container, _configuration.Object);

            // Assert
            container.Verify();
        }

        [Fact(DisplayName = "Bootstrapper throws ArgumentNullException if container is null.")]
        public void Bootstrap_Throws_WhenContainerIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => { Bootstrapper.Bootstrap(null!, _configuration.Object); });
        }
    }
}