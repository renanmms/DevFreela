using DevFreela.Application.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DevFreela.Application.Commands.ValidateRecoveryCode
{
    public record ValidateRecoveryCodeCommand(string Email, string RecoveryCode) : IRequest<ResultViewModel>;

    public class ValidateRecoveryCodeCommandHandler : IRequestHandler<ValidateRecoveryCodeCommand, ResultViewModel>
    {
        private readonly IMemoryCache _cache;
        public ValidateRecoveryCodeCommandHandler(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<ResultViewModel> Handle(ValidateRecoveryCodeCommand request, CancellationToken cancellationToken)
        {
            var cacheKey = $"RecoveryCode:{request.Email}";

            var hasValue = _cache.TryGetValue(cacheKey, out string? code);
            if(!hasValue || request.RecoveryCode != code)
            {
                return ResultViewModel.Error("Invalid recovery code");
            }

            return ResultViewModel.Success();
        }
    }
}