using DevFreela.Application.Commands.LoginUser;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class LoginUserCommandHandlerTests
    {
        [Fact]
        public async void LoginAndPassword_Login_LoginSuccessful()
        {
            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var request = new LoginUserCommand{
                Email = "guilherme@email.com",
                Password = "Teste@1234"
            };

            var loginCommandHandler = new LoginUserCommandHandler(authServiceMock.Object, userRepositoryMock.Object);

            // Act
            var login = await loginCommandHandler.Handle(request, new CancellationToken());

            // Assert
            Assert.NotNull(login);
        }     
    }
}