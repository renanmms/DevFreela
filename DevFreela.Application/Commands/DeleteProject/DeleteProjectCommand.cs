using DevFreela.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.DeleteProject
{
    public class DeleteProjectCommand : IRequest<ProjectStatusEnum>
    {
        public int Id { get; set; }
    }
}
