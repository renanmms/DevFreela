using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, int idClient, int idFreelancer,  decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int IdClient { get; set; }
        public int IdFreelancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}
