using DevFreela.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommand : IRequest<ProjectStatusEnum>
    {
        public int Id;
    }
}
