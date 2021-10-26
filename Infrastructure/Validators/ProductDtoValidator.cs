using Domain.POCO.DTOs;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.plu)
                .Must(IsValidPLU).WithMessage("it can be range 1-99999")
                  .NotNull().WithMessage("it can't be null")
                   .NotEmpty().WithMessage("it can't be Empty");
            RuleFor(x => x.bc)
                .MaximumLength(13).WithMessage("it lenght must be maximum 13 characters")
                .MinimumLength(13).WithMessage("it lenght must be minimum 13 characters")
                .NotEmpty().WithMessage("it can't be Empty");
            RuleFor(x => x.p)//todo price rounded to nearest 10
                .Must(IsValidRange).WithMessage("it can be range 10-5000")
                   .NotNull().WithMessage("it can't be null")
                   .NotEmpty().WithMessage("it can't be Empty");
            RuleFor(x => x.n)
                .MaximumLength(15).WithMessage("it lenght must be maximum 15 characters")
                .MinimumLength(5).WithMessage("it lenght must be minimum 5 characters")
                   .NotNull().WithMessage("it can't be null")
                   .NotEmpty().WithMessage("it can't be Empty");
        }

        private bool IsValidPLU(int arg) => arg >= 1 && arg <= 99999;

        private bool IsValidRange(decimal arg) => arg >= 10 && arg <= 5000;
    }
}