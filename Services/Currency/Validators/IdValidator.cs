using FluentValidation;

namespace Currency.Validators
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
