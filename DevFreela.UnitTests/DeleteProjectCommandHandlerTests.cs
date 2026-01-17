using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using FluentAssertions;
using Moq;
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
        result.IsSuccess.Should().BeTrue();
        await repository.Received(1).GetByIdAsync(Arg.Any<int>());
        await repository.Received(1).UpdateAsync(Arg.Any<Project>());
    }
    
    [Fact]
    public async Task ProjectExists_Delete_Success_Moq() 
    {
        // Arrange
        const int ID = 1;
        var project = new Project("Project A", "Project Description", 1, 2, 20000);
        var repository = Mock.Of<IProjectRepository>(p => 
            p.GetByIdAsync(It.IsAny<int>()) == Task.FromResult(project) &&
            p.UpdateAsync(It.IsAny<Project>()) == Task.CompletedTask);
        
        var handler = new DeleteProjectCommandHandler(repository);
        var command = new DeleteProjectCommand(ID);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        Mock.Get(repository).Verify(m => m.GetByIdAsync(It.IsAny<int>()), Times.Once);
        Mock.Get(repository).Verify(m => m.UpdateAsync(It.IsAny<Project>()), Times.Once);
    }

    [Fact]
    public async Task ProjectDoesNotExists_Delete_Error_NSubstitute()
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
        result.IsSuccess.Should().BeFalse();
        await repository.Received(1).GetByIdAsync(Arg.Any<int>());
        await repository.DidNotReceive().UpdateAsync(Arg.Any<Project>());
        result.Message.Should().Be(DeleteProjectCommandHandler.PROJECT_NOT_FOUND_MESSAGE);
    }
    
    [Fact]
    public async Task ProjectDoesNotExists_Delete_Error_Moq()
    {
        // Arrange
        const int ID = 1;
        var repository = Mock.Of<IProjectRepository>(r => r.GetByIdAsync(It.IsAny<int>()) == Task.FromResult((Project?)null));
        
        var handler = new DeleteProjectCommandHandler(repository);
        var command = new DeleteProjectCommand(ID);
        
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Message.Should().Be(DeleteProjectCommandHandler.PROJECT_NOT_FOUND_MESSAGE);
        Mock.Get(repository).Verify(r => r.GetByIdAsync(It.IsAny<int>()), Times.Once);
        Mock.Get(repository).Verify(r => r.UpdateAsync(It.IsAny<Project>()), Times.Never);
    }
}