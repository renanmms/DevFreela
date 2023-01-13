using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.DTOs
{
    public class ProjectDTO
    {
        public ProjectDTO(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
    }
}
