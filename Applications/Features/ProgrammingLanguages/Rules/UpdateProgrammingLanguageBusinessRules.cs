using Applications.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.ElasticSearch.Models;
using Core.Persistence.Paging;
using Domain.Entities;
using Nest;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Features.ProgrammingLanguages.Rules
{
    public class UpdateProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly UpdateProgrammingLanguageBusinessRules _updateProgrammingLanguageBusinessRules;
        private readonly IMapper _mapper;
        public UpdateProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, UpdateProgrammingLanguageBusinessRules updateProgrammingLanguageBusinessRules)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _updateProgrammingLanguageBusinessRules = updateProgrammingLanguageBusinessRules;
            _mapper=mapper;
            
        }
        public void ShouldExist(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested Programming Language does not exists.");
            _updateProgrammingLanguageBusinessRules.ShouldExist(programmingLanguage);

        }
        public async Task ProgrammingLanguageIdCanNotBeDuplicatedWhenInserted(int id)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p=>p.Id==id);
            if (result.Items.Any()) throw new BusinessException("Programming Language name exists.");
        }
    }
}
