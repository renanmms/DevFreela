using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using Moq;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task LoginData_Executed_UserId(){

            // Arrange
            var userRepositoryMock = new Mock<IUserRepository>();
            var authServiceMock = new Mock<IAuthService>();

            var command = new CreateUserCommand{
                FullName = "Renan Martins",
                Email = "renanmartins@email.com",
                BirthDate = DateTime.Now,
                Password = "renan1234",
                Role = "freelancer"
            };

            var createUserCommandHandler = new CreateUserCommandHandler(userRepositoryMock.Object, authServiceMock.Object);

            // Act
            var id = await createUserCommandHandler.Handle(command, new CancellationToken());

            // Assert
            Assert.True(id > 0);
        }
    }
}