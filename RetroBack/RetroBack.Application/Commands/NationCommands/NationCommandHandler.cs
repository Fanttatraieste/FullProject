using MediatR;
using Microsoft.EntityFrameworkCore;
using RetroBack.Application.Common;
using RetroBack.Application.Models;
using RetroBack.Common.Constants;
using RetroBack.Domain.Entities;
using RetroBack.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Application.Commands.NationCommands
{
    public  class NationCommandHandler : 
        IRequestHandler<CreateNationCommand, CommandResponse<NationDto>>,
        IRequestHandler<UpdateNationCommand, CommandResponse>,
        IRequestHandler<DeleteNationCommand, CommandResponse>
    {
        private readonly IRepository<Nation> _nationRepository;
        public NationCommandHandler(IRepository<Nation> nationRepository)
        {
            _nationRepository = nationRepository;
        }

        public async Task<CommandResponse<NationDto>> Handle(CreateNationCommand request, CancellationToken cancellationToken)
        {
            request.NationDto.NationId = Guid.NewGuid();

            var newNation = new Nation()
            {
                NationID = request.NationDto.NationId,
                NationName = request.NationDto.NationName,
                Confederation = request.NationDto.Confederation,
            };

            _nationRepository.Add(newNation);

            await _nationRepository.SaveChangesAsync();

            return await Task.FromResult(CommandResponse<NationDto>.Ok(request.NationDto));
        }

        public async Task<CommandResponse> Handle(UpdateNationCommand request, CancellationToken cancellationToken)
        {
            var existingNation = await _nationRepository.Query(n => n.NationID == request.NationDto.NationId).FirstOrDefaultAsync();

            if (existingNation == null)
            {
                return CommandResponse.Failed(ErrorMessages.Nation_Does_Not_Exist);
            }

            existingNation.NationName = request.NationDto.NationName;
            existingNation.Confederation = request.NationDto.Confederation;

            await _nationRepository.SaveChangesAsync();
            return CommandResponse.Ok();
        }

        public async Task<CommandResponse> Handle(DeleteNationCommand request, CancellationToken cancellationToken)
        {
            var existingNation = await _nationRepository.Query(n => n.NationID == request.NationId).FirstOrDefaultAsync();

            if (existingNation == null)
            {
                return CommandResponse.Failed(ErrorMessages.Nation_Does_Not_Exist);
            }

            _nationRepository.Remove(existingNation);

            await _nationRepository.SaveChangesAsync();

            return CommandResponse.Ok();    
        }
    }
}
