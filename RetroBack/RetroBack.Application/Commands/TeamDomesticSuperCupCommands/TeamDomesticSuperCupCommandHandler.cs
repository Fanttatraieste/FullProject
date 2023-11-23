using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Commands.TeamDomesticSuperCupCommands
{
    public class TeamDomesticSuperCupCommandHandler:
        IRequestHandler<CreateTeamDomesticSuperCupCommand, CommandResponse<TeamDomesticSuperCupDto>>,
        IRequestHandler<UpdateTeamDomesticSuperCupCommand, CommandResponse>,
        IRequestHandler<DeleteTeamDomesticSuperCupCommand, CommandResponse>
    {
        private readonly IRepository<TeamDomesticSuperCup> _superCupRepository;

        public TeamDomesticSuperCupCommandHandler(IRepository<TeamDomesticSuperCup> superCupRepository)
        {
            _superCupRepository = superCupRepository;
        }

        public async Task<CommandResponse<TeamDomesticSuperCupDto>> Handle(CreateTeamDomesticSuperCupCommand request, CancellationToken cancellationToken)
        {
            request.TeamDomesticSuperCupDto.DomesticSuperCupID = Guid.NewGuid();

            var newSuperCup = new TeamDomesticSuperCup()
            {
                DomesticSuperCupID = request.TeamDomesticSuperCupDto.DomesticSuperCupID,
                Country = request.TeamDomesticSuperCupDto.Country,
                WinnerId = request.TeamDomesticSuperCupDto.WinnerId,
                Year = request.TeamDomesticSuperCupDto.Year,
            };

            _superCupRepository.Add(newSuperCup);

            await _superCupRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(CommandResponse<TeamDomesticSuperCupDto>.Ok(request.TeamDomesticSuperCupDto));
        }

        public async Task<CommandResponse> Handle(UpdateTeamDomesticSuperCupCommand request, CancellationToken cancellationToken)
        {
            var existingSuperCup = await _superCupRepository.Query(s => s.DomesticSuperCupID == request.TeamDomesticSuperCupDto.DomesticSuperCupID).FirstOrDefaultAsync(cancellationToken);

            if (existingSuperCup == null)
            {
                return CommandResponse.Failed(ErrorMessages.DomesticSuperCup_Does_Not_Exist);
            }

            existingSuperCup.Year = request.TeamDomesticSuperCupDto.Year;
            existingSuperCup.Country = request.TeamDomesticSuperCupDto.Country;
            existingSuperCup.WinnerId = request.TeamDomesticSuperCupDto.WinnerId;

            await _superCupRepository.SaveChangesAsync(cancellationToken);
            return CommandResponse.Ok();
        }

        public async Task<CommandResponse> Handle(DeleteTeamDomesticSuperCupCommand request, CancellationToken cancellationToken)
        {
            var existingSuperCup = await _superCupRepository.Query(s => s.DomesticSuperCupID == request.DomesticSuperCupId).FirstOrDefaultAsync(cancellationToken);

            if (existingSuperCup == null)
            {
                return CommandResponse.Failed(ErrorMessages.DomesticSuperCup_Does_Not_Exist);
            }

            _superCupRepository.Remove(existingSuperCup);

            await _superCupRepository.SaveChangesAsync(cancellationToken);
            return CommandResponse.Ok();
        }
    }
}
