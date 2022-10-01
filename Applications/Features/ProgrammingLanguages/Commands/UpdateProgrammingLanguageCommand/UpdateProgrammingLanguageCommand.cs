using Applications.Features.ProgrammingLanguages.Dtos.Update;
using Applications.Features.ProgrammingLanguages.Rules;
using Applications.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguageCommand
{
    public class UpdateProgrammingLanguageCommand: IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingLanguageHandler: IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly UpdateProgrammingLanguageBusinessRules _updateProgrammingLanguageBusinessRules;
            public UpdateProgrammingLanguageHandler(IProgrammingLanguageRepository progrramingLanguageRepository, IMapper mapper, UpdateProgrammingLanguageBusinessRules updateProgrammingLanguageBusinessRules)
            {
                _programmingLanguageRepository = progrramingLanguageRepository;
                _updateProgrammingLanguageBusinessRules = updateProgrammingLanguageBusinessRules;
                _mapper = mapper;
            }

            public UpdateProgrammingLanguageHandler()
            {
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                _updateProgrammingLanguageBusinessRules.ShouldExist(programmingLanguage);
                _mapper.Map(request, programmingLanguage);
                ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                UpdateProgrammingLanguageDto updateProgrammingLanguageDto = _mapper.Map<UpdateProgrammingLanguageDto>(updatedProgrammingLanguage);
                return updateProgrammingLanguageDto;

            }
        }

    }
}
