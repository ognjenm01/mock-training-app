using Moq;
using Xunit;
using TrainingAppBackend.Services;
using TrainingAppBackend.DTO;
using TrainingAppBackend.Models;

namespace TrainingAppBackend.Tests
{
    public class AuthServiceTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IJwtService> _mockJwtService;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockJwtService = new Mock<IJwtService>();
            _authService = new AuthService(_mockUserService.Object, _mockJwtService.Object);
        }

        [Fact]
        public async Task Login_Successful_ReturnsJwt()
        {
            var request = new LoginRequestDTO { Username = "testUser", Password = "password123" };
            var user = new User(1, "testUser", "UZ95WzRsLThbyxvP78BSGu49+eSM3E6P2uL6tq93v5Y=", new List<Training>());
            _mockUserService.Setup(u => u.GetByUsername(It.IsAny<string>())).ReturnsAsync(user);
            _mockJwtService.Setup(j => j.GenerateToken(It.IsAny<int>(), It.IsAny<string>())).Returns("generated_jwt_token");

            var result = await _authService.Login(request);

            Assert.NotNull(result);
            Assert.Equal("generated_jwt_token", result?.token);
        }

        [Fact]
        public async Task Login_InvalidPassword_ReturnsNull()
        {
            var request = new LoginRequestDTO { Username = "testUser", Password = "wrongPassword" };
            var user = new User(1, "testUser", "UZ95WzRsLThbyxvP78BSGu49+eSM3E6P2uL6tq93v5Y=", new List<Training>());
            _mockUserService.Setup(u => u.GetByUsername(It.IsAny<string>())).ReturnsAsync(user);

            var result = await _authService.Login(request);

            Assert.Null(result);
        }

        [Fact]
        public async Task Login_UserNotFound_ReturnsNull()
        {
            var request = new LoginRequestDTO { Username = "nonExistentUser", Password = "password123" };
            _mockUserService.Setup(u => u.GetByUsername(It.IsAny<string>())).ReturnsAsync((User?)null);

            var result = await _authService.Login(request);

            Assert.Null(result);
        }

        [Fact]
        public async Task Register_Successful_ReturnsJwt()
        {
            var request = new RegisterRequestDTO { Username = "newUser", Password = "newPassword123" };
            var newUser = new User(1, "newUser", "UZ95WzRsLThbyxvP78BSGu49+eSM3E6P2uL6tq93v5Y=", new List<Training>());
            _mockUserService.Setup(u => u.GetMaxId()).ReturnsAsync(1);
            _mockUserService.Setup(u => u.AddUser(It.IsAny<User>())).ReturnsAsync(newUser);
            _mockJwtService.Setup(j => j.GenerateToken(It.IsAny<int>(), It.IsAny<string>())).Returns("generated_jwt_token");

            var result = await _authService.Register(request);

            Assert.NotNull(result);
            Assert.Equal("generated_jwt_token", result?.token);
        }

        [Fact]
        public async Task Register_UserExists_ReturnsNull()
        {
            var request = new RegisterRequestDTO { Username = "existingUser", Password = "newPassword123" };
            var existingUser = new User(1, "existingUser", "UZ95WzRsLThbyxvP78BSGu49+eSM3E6P2uL6tq93v5Y=", new List<Training>());
            _mockUserService.Setup(u => u.GetByUsername(It.IsAny<string>())).ReturnsAsync(existingUser);

            var result = await _authService.Register(request);

            Assert.Null(result);
        }


    }
}
