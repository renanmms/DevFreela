namespace DevFreela.API.Models
{
    public class ProjectItemViewModel
    {
        public int Id { get; private set; }
         public string Title { get; private set; }
        public string ClientName { get; private set; }
        public string FreelancerName { get; private set; }
        public decimal TotalCost { get; private set; }
    }
}