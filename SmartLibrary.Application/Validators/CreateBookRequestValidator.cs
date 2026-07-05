using FluentValidation;
using SmartLibrary.Application.DTOs.Books.Requests;

namespace SmartLibrary.Application.Validators;

public class CreateBookRequestValidator: AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Title)
        .NotEmpty().WithMessage("Book Must have Title")
        .Length(3,50);

        RuleFor( d => d.Description)
        .Length(1,1000);

        RuleFor( y => y.Year)
        .Must(MaxCurrentYear);
    }

    private bool MaxCurrentYear(int year)
    {
        return year >=1 && year <= DateTime.Now.Year;
    }
}