using MediatR;
using RetroBack.Application.Models;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;


namespace RetroBack.Application.Queries.AccountQueries
{
    public class AccountQueryHandler : IRequestHandler<GetLoggedInUserQuery, ApplicationUserDto>
    {
        private readonly IRepository<ApplicationUser> _userRepository;

        public AccountQueryHandler(IRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUserDto> Handle(GetLoggedInUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.Query(u => u.Id == request.User.UserId).ProjectToDto().FirstOrDefaultAsync(cancellationToken);
        }
    }
}
