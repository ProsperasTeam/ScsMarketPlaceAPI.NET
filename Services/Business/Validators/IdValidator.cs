using FluentValidation;

namespace Business.Validators
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
