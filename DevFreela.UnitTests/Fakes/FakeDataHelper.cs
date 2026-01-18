using Bogus;
using DevFreela.Application.Commands.InsertProject;
using DevFreela.Core.Entities;

namespace DevFreela.UnitTests.Fakes;

public class FakeDataHelper
{
    private static readonly Faker _faker = new();
    
    private static Faker<Project> _projectFakerV1 =>
         new Faker<Project>()
            .CustomInstantiator(f => new Project(f.Commerce.Product(),
                f.Lorem.Sentence(),
                f.Random.Int(1, 100),
                f.Random.Int(1, 100),
                f.Random.Decimal(1000, 10000)));

    private static Faker<Project> _projectFakerV2 =>
        new Faker<Project>()
            .RuleFor(p => p.Title, f => f.Commerce.Product())
            .RuleFor(p => p.Description, f => f.Lorem.Sentence())
            .RuleFor(p => p.IdClient, f => f.Random.Int(1, 100))
            .RuleFor(p => p.IdFreelancer, f => f.Random.Int(1, 100))
            .RuleFor(p => p.TotalCost, f => f.Random.Decimal(1000, 10000));
    
    private static Faker<InsertProjectCommand> _insertProjectFaker =>
        new Faker<InsertProjectCommand>()
            .CustomInstantiator(f => new InsertProjectCommand(
                f.Commerce.Product(),
                f.Lorem.Sentence(),
                f.Random.Int(1, 100),
                f.Random.Int(1, 100),
                f.Random.Decimal(1000, 10000)));

    public static Project CreateFakeProject() => _projectFakerV1.Generate();
    public static List<Project> CreateFakeProjectsList(int n) => _projectFakerV2.Generate(n);
    public static InsertProjectCommand CreateInsertProjectCommand() => _insertProjectFaker.Generate();
}