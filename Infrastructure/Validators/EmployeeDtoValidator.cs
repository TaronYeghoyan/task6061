using Domain.POCO.DTOs;
using FluentValidation;
using System;

namespace Infrastructure.Validators
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(x => x.wd)
                .Must(IValidWorkDays).WithMessage("it can be 1-7");
            RuleFor(x => x.w)
                .Must(IsValidWage).WithMessage("it can be 10-1000 and divisible to 10");
            RuleFor(x => x.d)
                .Must(IsValidDate).WithMessage("date from 01.01.1940 to 31.12.1995 or nothing");
            RuleFor(x => x.ln)
                .NotNull().WithMessage("it can't be null")
                .NotEmpty().WithMessage("it can't be Empty")
                .Length(5, 15).WithMessage("length must be 5-15 characters ");
            RuleFor(x => x.fn)
                .NotNull().WithMessage("it can't be null")
                .NotEmpty().WithMessage("it can't be Empty");
        }

        private bool IValidWorkDays(byte arg) => arg >= 1 && arg <= 7;

        private bool IsValidWage(int arg) => arg >= 10 && arg <= 1000 && arg % 10 == 0;

        private bool IsValidDate(DateTime? date) => date != null ? date <= new DateTime(1995, 12, 31) && date >= new DateTime(1940, 1, 1) : true;
    }
}