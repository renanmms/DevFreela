using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTests;

public class DeleteProjectCommandHandlerTests
{
    [Fact]
    public async Task ProjectExists_Delete_Success_NSubstitute() 
    {
        // Arrange
        const int ID = 1;
        var project = new Project("Project A", "Project Description", 1, 2, 20000);
        var repository = Substitute.For<IProjectRepository>();
        repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Project?>(project));
        repository.UpdateAsync(Arg.Any<Project>()).Returns(Task.CompletedTask);
        
        var handler = new DeleteProjectCommandHandler(repository);
        var command = new DeleteProjectCommand(ID);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.True(result.IsSuccess);
        await repository.Received(1).GetByIdAsync(Arg.Any<int>());
        await repository.Received(1).UpdateAsync(Arg.Any<Project>());
    }

    [Fact]
    public async Task ProjectDoesExists_Delete_Error_NSubstitute()
    {
        // Arrange
        const int ID = 1;
        var repository = Substitute.For<IProjectRepository>();
        repository.GetByIdAsync(Arg.Any<int>()).Returns(Task.FromResult<Project?>(null));
        
        var handler = new DeleteProjectCommandHandler(repository);
        var command = new DeleteProjectCommand(ID);
        
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        Assert.False(result.IsSuccess);
        await repository.Received(1).GetByIdAsync(Arg.Any<int>());
        await repository.DidNotReceive().UpdateAsync(Arg.Any<Project>());
        Assert.Equal(DeleteProjectCommandHandler.PROJECT_NOT_FOUND_MESSAGE, result.Message);
    }
}