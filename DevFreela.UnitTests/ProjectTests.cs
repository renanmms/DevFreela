using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using FluentAssertions;

namespace DevFreela.UnitTests;

public class ProjectTests
{
    [Fact]
    public void Project_Start_ProjectStarted()
    {
        // Arrange
        var project = new Project("Project title", "Project description", 1, 1, 1000M);
        
        // Act
        project.Start();

        // Assert
        project.StartedAt.Should().NotBeNull();
        project.Status.Should().Be(ProjectStatusEnum.InProgress);
    }

    [Fact]
    public void ProjectStarted_Complete_ProjectCompleted()
    {
        // Arrange
        var project = new Project("Project Started", "Project description", 1, 1, 1000M);
        project.Start();
        
        // Act
        project.Complete();

        // Assert
        project.CompletedAt.Should().NotBeNull();
        project.Status.Should().Be(ProjectStatusEnum.Completed);
    }
    
    [Fact]
    public void ProjectWithPaymentPending_Complete_ProjectCompleted()
    {
        // Arrange
        var project = new Project("Project Started", "Project description", 1, 1, 1000M);
        project.SetPaymentPending();
        
        // Act
        project.Complete();

        // Assert
        project.CompletedAt.Should().NotBeNull();
        project.Status.Should().Be(ProjectStatusEnum.Completed);
    }
}