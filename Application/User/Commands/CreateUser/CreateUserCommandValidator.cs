using FluentValidation;

namespace Application.User.Commands.CreateUser;

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(d => d.Name)
            .NotNull().WithMessage("{PropertyName} required")
            .MinimumLength(5).WithMessage("{PropertyName} at least {MinLength} characters")
            .MaximumLength(100).WithMessage("{PropertyName} up to {MaxLength} characters");
    }
}