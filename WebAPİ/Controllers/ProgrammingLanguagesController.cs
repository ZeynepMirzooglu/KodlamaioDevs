using Applications.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguageCommand;
using Applications.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageCommand;
using Applications.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguageCommand;
using Applications.Features.ProgrammingLanguages.Dtos;
using Applications.Features.ProgrammingLanguages.Dtos.Delete;
using Applications.Features.ProgrammingLanguages.Dtos.Update;
using Applications.Features.ProgrammingLanguages.Models;
using Applications.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Applications.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController:BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
           GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(programmingLanguageGetByIdDto);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdateProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);

            return Ok(result);
        }
    }
}
