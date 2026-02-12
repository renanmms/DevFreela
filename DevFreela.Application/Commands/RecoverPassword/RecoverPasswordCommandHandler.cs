using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Notifications;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Application.Commands.RecoverPassword;

public class RecoverPasswordCommandHandler : IRequestHandler<RecoverPasswordCommand, ResultViewModel>
{
    private readonly IEmailService _emailService;
    private readonly IUserRepository _userRepository;
    private readonly IMemoryCache _cache;
    
    public RecoverPasswordCommandHandler(
        IEmailService emailService,
        IUserRepository userRepository,
        IMemoryCache cache)
    {
        _emailService = emailService;
        _userRepository = userRepository;
        _cache = cache;
    }
    
    public async Task<ResultViewModel> Handle(RecoverPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await  _userRepository.GetByEmailAsync(request.Email);
        if (user is null) {
            return ResultViewModel.Error("Email not found");
        }
        
        var code = new Random()
            .Next(100000, 999999)
            .ToString();
        
        var cacheKey = $"RecoveryCode:{request.Email}";
        _cache.Set(cacheKey, code, TimeSpan.FromMinutes(10));

        await _emailService.SendAsync(request.Email, "Recovery Code", $"This is your recovery code: {code}");
        
        return ResultViewModel.Success();
    }
}