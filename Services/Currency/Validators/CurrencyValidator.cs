using FluentValidation;
using cu = Currency.DataAccess.Entities;

namespace Currency.Validators
{
    public class CurrencyValidator : AbstractValidator<cu.Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
        }
    }
}
