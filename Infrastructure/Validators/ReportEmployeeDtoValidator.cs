using Domain.POCO.DTOs;
using FluentValidation;

namespace Infrastructure.Validators
{
    public sealed class ReportEmployeeDtoValidator : AbstractValidator<ReportEmployeeDto>
    {
        public ReportEmployeeDtoValidator()
        {
            RuleFor(x => x.ds.Ticks < x.de.Ticks)
                .Must(IsValid)
                .WithMessage("Start Date և End Date not correct");
            RuleFor(x => x.ds)
                .NotNull().WithMessage("it can't be null")
                .NotEmpty().WithMessage("it can't be Empty");

            RuleFor(x => x.de)
                .NotNull().WithMessage("it can't be null")
                .NotEmpty().WithMessage("it can't be Empty");

            RuleFor(x => x.dn != null)
                .NotNull().WithMessage("it can't be null");

            RuleFor(x => x.we)
                .NotNull().WithMessage("it can't be null")
                .NotEmpty().WithMessage("it can't be Empty");
            RuleFor(x => x.we)
                .Must(IsValidWage).WithMessage("it can be range  0-1000");

            RuleFor(x => x.ws)
                .NotNull().WithMessage("it can't be null")
                .NotEmpty().WithMessage("it can't be Empty");
            RuleFor(x => x.ws)
              .Must(IsValidWage).WithMessage("it can be range  0-1000");
        }

        private bool IsValid(bool arg) => arg;

        private bool IsValidWage(int arg) => arg >= 0 && arg <= 1000;
    }
}