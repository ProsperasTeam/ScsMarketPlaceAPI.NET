using FluentValidation;
using be = Business.DataAccess.Entities;

namespace Business.Validators
{
    public class BusinessValidator : AbstractValidator<be.Business>
    {
        public BusinessValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.ConsumerId).NotEmpty();
        }
    }
}
