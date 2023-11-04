using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;

namespace RetroBack.Application.Commands.IconCommands
{
    public class IconCommandHandler : 
        IRequestHandler<CreateIconCommand, CommandResponse<IconDto>>,
        IRequestHandler<UpdateIconCommand, CommandResponse>,
        IRequestHandler<DeleteIconCommand, CommandResponse>
    {
        private readonly IRepository<Icon> _iconRepository;
        public IconCommandHandler(IRepository<Icon> iconRepository)
        {
            _iconRepository = iconRepository;
        }

        public async Task<CommandResponse<IconDto>> Handle(CreateIconCommand request, CancellationToken cancellationToken)
        {
            request.IconDto.IconId = Guid.NewGuid();

            var newIcon = new Icon()
            {
                IconId = request.IconDto.IconId,
                FirstName = request.IconDto.FirstName,
                LastName = request.IconDto.LastName,
                Nickname = request.IconDto.Nickname,
                YearOfBirth = request.IconDto.YearOfBirth,
                CareerLengthInYears = request.IconDto.CareerLengthInYears,
                CareerGames = request.IconDto.CareerGames,
                CareerGoals = request.IconDto.CareerGoals,
                RetiredInYear = request.IconDto.RetiredInYear,
                Description = request.IconDto.Description,
                Position = request.IconDto.Position.ToLower(),
            };

            _iconRepository.Add(newIcon);

            await _iconRepository.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(CommandResponse<IconDto>.Ok(request.IconDto));
        }

        public async Task<CommandResponse> Handle(UpdateIconCommand request, CancellationToken cancellationToken)
        {
            var existingIcon = await _iconRepository.Query(i => i.IconId == request.IconDto.IconId).FirstOrDefaultAsync(cancellationToken);
        
            if (existingIcon == null)
            {
                return CommandResponse.Failed(ErrorMessages.Icon_Does_Not_Exist);
            }

            existingIcon.FirstName = request.IconDto.FirstName;
            existingIcon.LastName = request.IconDto.LastName;
            existingIcon.Nickname = request.IconDto.Nickname;
            existingIcon.Position = request.IconDto.Position;
            existingIcon.Description = request.IconDto.Description;
            existingIcon.CareerGames = request.IconDto.CareerGames;
            existingIcon.CareerGoals = request.IconDto.CareerGoals;
            existingIcon.CareerLengthInYears = request.IconDto.CareerLengthInYears;
            existingIcon.YearOfBirth = request.IconDto.YearOfBirth;
            existingIcon.RetiredInYear = request.IconDto.RetiredInYear;
            
            await _iconRepository.SaveChangesAsync(cancellationToken);
            return CommandResponse.Ok();
        }

        public async Task<CommandResponse> Handle(DeleteIconCommand request, CancellationToken cancellationToken)
        {
            var existingIcon = await _iconRepository.Query(i => i.IconId == request.IconId).FirstOrDefaultAsync(cancellationToken);

            if (existingIcon == null)
            {
                return CommandResponse.Failed(ErrorMessages.Icon_Does_Not_Exist);
            }

            _iconRepository.Remove(existingIcon);

            await _iconRepository.SaveChangesAsync(cancellationToken);

            return CommandResponse.Ok();
        }
    }
}
