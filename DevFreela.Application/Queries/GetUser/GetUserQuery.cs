using DevFreela.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserDetailsViewModel>
    {
        public int Id { get; private set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
