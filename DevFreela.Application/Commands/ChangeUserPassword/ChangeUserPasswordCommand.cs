using DevFreela.Application.Models;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Auth;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Application.Commands.ChangeUserPassword
{
    public record ChangeUserPasswordCommand(string Email, string RecoveryCode, string Password) 
        : IRequest<ResultViewModel>;


    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, ResultViewModel>
    {
        private readonly IUserRepository _repository;
        private readonly IMemoryCache _cache;
        private readonly IAuthService _authService;
        private readonly DevFreelaDbContext _context;
        public ChangeUserPasswordCommandHandler(IMemoryCache cache,
         IUserRepository repository,
         IAuthService authService,
         DevFreelaDbContext context)
        {
            _cache = cache;
            _repository = repository;
            _authService = authService;
            _context = context;
        }

        public async Task<ResultViewModel> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByEmailAsync(request.Email);

            if(user is null)
            {
                return ResultViewModel.Error("User not found!");
            }

            var cacheKey = $"RecoveryCode:{request.Email}";

            var hasValue = _cache.TryGetValue(cacheKey, out string? code);
            if(!hasValue || request.RecoveryCode != code)
            {
                return ResultViewModel.Error("Invalid recovery code");
            }

            _cache.Remove(cacheKey);

            var hash = _authService.ComputeHash(request.Password);

            user.UpdatePassword(hash);
            await _context.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
    }
}