using CourseRegistrationAPI.DTOs;
using FluentValidation;

namespace CourseRegistrationAPI.Validators
{
    public class CreateCourseValidator : AbstractValidator<CreateCourseDto>
    {
        public CreateCourseValidator()
        {
            // Titeln får inte vara tom och måste vara mellan 3 och 100 tecken
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Titel är obligatoriskt")
                .MinimumLength(3).WithMessage("Titeln måste vara minst 3 tecken")
                .MaximumLength(100).WithMessage("Titeln får max vara 100 tecken");

            // Beskrivningen får inte vara tom
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Beskrivning är obligatoriskt");

            // Poängen måste vara mellan 1 och 30
            RuleFor(x => x.Credits)
                .InclusiveBetween(1, 30).WithMessage("Poäng måste vara mellan 1 och 30");
        }
    }
}