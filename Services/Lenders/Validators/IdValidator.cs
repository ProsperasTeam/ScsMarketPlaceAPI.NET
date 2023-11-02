using FluentValidation;

namespace Lenders.Validators
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
