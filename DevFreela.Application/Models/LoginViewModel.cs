namespace DevFreela.Application.Models;

public record LoginViewModel(
    int IdClient,
    string FullName,
    string Role,
    string Token);