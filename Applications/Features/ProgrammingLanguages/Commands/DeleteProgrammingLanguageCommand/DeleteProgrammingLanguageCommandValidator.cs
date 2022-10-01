using FluentValidation;

namespace Applications.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageCommand;

public class DeleteProgrammingLanguageCommandValidator : AbstractValidator<DeleteProgrammingLanguageCommand>
{
    public DeleteProgrammingLanguageCommandValidator()
    {
        RuleFor(p => p.Id).NotNull();
    }
}