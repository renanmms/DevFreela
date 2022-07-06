using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Projeto ASP.NET Core 1", "Testando DbContext com o projeto 1", 1, 1, 10000),
                new Project("Projeto ASP.NET Core 2", "Testando DbContext com o projeto 2", 2, 2, 20000),
                new Project("Projeto ASP.NET Core 3", "Testando DbContext com o projeto 3", 3, 3, 30000)
            };

            Users = new List<User>
            {
                new User("Renan Martins Mendes da Silva", "email1@hotmail.com", new DateTime(1999, 12, 4)),
                new User("Matheus José da Silva", "email2@hotmail.com", new DateTime(2000, 12, 20)),
                new User("Felipe Silva da Cunha", "email3@hotmail.com", new DateTime(1998, 4, 3))
            };

            Skills = new List<Skill>
            {
                new Skill("C#, .NET 6, ASP.NET Core"),
                new Skill("HTML, CSS, JavaScript"),
                new Skill("HTML, CSS, PHP")

            };
        }
        public List<Project> Projects { get; set; }
        public List<Skill> Skills { get; set; }
        public List<User> Users { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
