using CourseRegistrationAPI.DTOs;
using FluentValidation;

namespace CourseRegistrationAPI.Validators
{
    public class CreateEnrollmentValidator : AbstractValidator<CreateEnrollmentDto>
    {
        public CreateEnrollmentValidator()
        {
            // UserId måste vara större än 0
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId måste vara ett giltigt id");

            // CourseId måste vara större än 0
            RuleFor(x => x.CourseId)
                .GreaterThan(0).WithMessage("CourseId måste vara ett giltigt id");
        }
    }
}