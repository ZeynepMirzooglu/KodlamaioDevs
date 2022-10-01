using Applications.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguageCommand;
using Applications.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageCommand;
using Applications.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguageCommand;
using Applications.Features.ProgrammingLanguages.Dtos;
using Applications.Features.ProgrammingLanguages.Dtos.Delete;
using Applications.Features.ProgrammingLanguages.Dtos.Update;
using Applications.Features.ProgrammingLanguages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applications.Features.ProgrammingLanguages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<DeletedProgrammingLanguageDto, ProgrammingLanguage>().ReverseMap();

        }
    }
}
