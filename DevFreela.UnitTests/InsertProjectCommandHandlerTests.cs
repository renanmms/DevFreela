using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Notifications.ProjectCreated;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using MediatR;
using Moq;
using NSubstitute;

namespace DevFreela.UnitTests;

public class InsertProjectCommandHandlerTests
{
    [Fact]
    public async Task InputDataAreOk_Insert_Success_NSubstitute()
    {
        // Arrange
        const int ID = 1;
        var repository = Substitute.For<IProjectRepository>();
        var mediator = Substitute.For<IMediator>();

        repository.AddAsync(Arg.Any<Project>())
            .Returns(Task.FromResult(ID));

        var command = new InsertProjectCommand("Project Title", "Project Description", 1, 2, 20000);
        var handler = new InsertProjectCommandHandler(repository, mediator);
        
        // Act
        var result = await handler.Handle(command, new CancellationToken());
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(ID, result.Data);
        await repository.Received(1).AddAsync(Arg.Any<Project>());
    }
    
    [Fact]
    public async Task InputDataAreOk_Insert_Success_Moq()
    {
        // Arrange
        const int ID = 1;
        var repository = Mock.Of<IProjectRepository>(p => p.AddAsync(It.IsAny<Project>()) == Task.FromResult(ID));
        var mediator = Mock.Of<IMediator>(m => m.Publish(It.IsAny<ProjectCreatedNotification>(), CancellationToken.None) == Task.CompletedTask);

        var command = new InsertProjectCommand("Project Title", "Project Description", 1, 2, 20000);
        var handler = new InsertProjectCommandHandler(repository, mediator);
        
        // Act
        var result = await handler.Handle(command, new CancellationToken());
        
        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal(ID, result.Data);
        Mock.Get(repository).Verify(p => p.AddAsync(It.IsAny<Project>()), Times.Once);
    }
}