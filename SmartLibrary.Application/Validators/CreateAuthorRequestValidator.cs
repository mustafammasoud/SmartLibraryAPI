using FluentValidation;
using SmartLibrary.Application.DTOs.Authors.Requests;

namespace SmartLibrary.Application.Validators;

public class CreateAuthorRequestValidator :AbstractValidator<CreateAuthorRequest>
{
    public CreateAuthorRequestValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("Author Must have a Name")
        .Length(3,50);

    }
}