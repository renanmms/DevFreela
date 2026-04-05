using DevFreela.Core.Entities;

namespace DevFreela.Application.Models;

public record FreelancerViewModel(int Id, string FullName)
{
    public static FreelancerViewModel FromEntity(User user)
    {
        return new FreelancerViewModel(user.Id, user.FullName);
    }
}
