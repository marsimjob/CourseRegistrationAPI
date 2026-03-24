using CourseRegistrationAPI.DTOs;
using FluentValidation;

namespace CourseRegistrationAPI.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            // Namnet får inte vara tomt och måste vara mellan 2 och 50 tecken
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Namn är obligatoriskt")
                .MinimumLength(2).WithMessage("Namnet måste vara minst 2 tecken")
                .MaximumLength(50).WithMessage("Namnet får max vara 50 tecken");

            // E-posten måste vara giltig och får inte vara tom
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-post är obligatoriskt")
                .EmailAddress().WithMessage("E-posten är inte giltig");

            // Rollen måste vara antingen Student eller Admin
            RuleFor(x => x.Role)
                .Must(r => r == "Student" || r == "Admin")
                .WithMessage("Roll måste vara 'Student' eller 'Admin'");
        }
    }
}