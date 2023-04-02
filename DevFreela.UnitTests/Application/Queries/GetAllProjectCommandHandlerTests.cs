using System;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Moq;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectCommandHandlerTests
    {
        [Fact]
        public async void ThreeProjectsExist_Executed_ReturnThreeProjectViewModels()
        {
            // Arrange
            var projects = new List<Project>
            {
                new Project("Title 1", "Description 1", 1, 2, 10000),
                new Project("Title 2", "Description 2", 1, 2, 20000),
                new Project("Title 3", "Description 3", 1, 2, 30000)
            };

            var projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(projects);

            var getAllProjects = new GetAllProjectsQuery("");
            var getAllProjectsHandler = new GetAllProjectsQueryHandler(projectRepositoryMock.Object);

            // Act
            var projectViewModelList = await getAllProjectsHandler.Handle(getAllProjects, new CancellationToken());

            // Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            projectRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);

        }
    }
}