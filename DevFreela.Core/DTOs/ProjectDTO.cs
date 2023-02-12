using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Core.Enums;

namespace DevFreela.Core.DTOs
{
    public class ProjectDTO
    {
        public ProjectDTO(int id, string title, string description, string status)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = status;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set; }
    }
}
