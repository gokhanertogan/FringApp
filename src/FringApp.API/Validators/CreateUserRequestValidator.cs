using System.Text.RegularExpressions;
using FluentValidation;
using FringApp.API.Models.Requests;

namespace FringApp.API.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequestModel>
{
    public CreateUserRequestValidator()
    {
        RuleFor(s => s.Email).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");

        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();

        RuleFor(p => p.CellPhone)
       .NotEmpty()
       .NotNull().WithMessage("Phone Number is required.")
       .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
       .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
       .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");

        RuleFor(x => x.Gender).NotNull().IsInEnum();

        RuleFor(x => x.ImageUrl).NotEmpty();
    }
}