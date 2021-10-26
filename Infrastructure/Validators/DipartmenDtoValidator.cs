using Domain.POCO.DTOs;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class DipartmenDtoValidator : AbstractValidator<DepartmentDto>
    {
        public DipartmenDtoValidator()
        {
            RuleFor(x => x.n)
                .NotNull().WithMessage("it can't be null")
                .NotEmpty().WithMessage("it can't be Empty");
        }
    }
}