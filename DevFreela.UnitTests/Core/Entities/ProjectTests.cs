using System;
using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            // Given
            var project = new Project("Nome de teste", "Descrição de teste", 1, 2, 10000); 
            project.Start();

            // When
            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

            // Then
        }
    }
}