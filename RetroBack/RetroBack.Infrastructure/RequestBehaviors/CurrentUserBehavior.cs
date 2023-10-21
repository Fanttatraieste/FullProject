using MediatR;
using RetroBack.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Infrastructure.RequestBehaviors
{
    public class CurrentUserBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ICurrentUserService _currentUserService;

        public CurrentUserBehavior(ICurrentUserService currentUserService) => _currentUserService = currentUserService;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            BaseRequest<TResponse> castedRequest = request as BaseRequest<TResponse>;
            castedRequest.User = await _currentUserService.GetCurrentUser();
            return await next();
        }
    }
}
