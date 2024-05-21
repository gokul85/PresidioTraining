using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Services;
using Microsoft.Extensions.Configuration;
using Moq;

namespace RequestTrackerTest
{
    public class TokenServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateTokenPassTest()
        {
            //Arrange
            Mock<IConfigurationSection> configurationJWTSection = new Mock<IConfigurationSection>();
            configurationJWTSection.Setup(x => x.Value).Returns("This is the dummy key which has to be a bit long for the 512. which should be even more longer for the passing");
            Mock<IConfigurationSection> configTokenSection = new Mock<IConfigurationSection>();
            configTokenSection.Setup(x => x.GetSection("JWT")).Returns(configurationJWTSection.Object);
            Mock<IConfiguration> mockConfig = new Mock<IConfiguration>();
            mockConfig.Setup(x => x.GetSection("TokenKey")).Returns(configTokenSection.Object);
            ITokenService service = new TokenService(mockConfig.Object);
            Mock<IConfiguration> test = new Mock<IConfiguration>();

            //Action
            var token = service.GenerateToken(new Employee { Id = 103, Role = "Admin" });

            //Assert
            Assert.IsNotNull(token);    
        }
    }
}