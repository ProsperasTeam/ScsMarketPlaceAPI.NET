using FluentValidation;
using  Lenders.DataAccess.Entities;
using System.Reflection;

namespace Lenders.Validators
{
    public class LenderValidator : AbstractValidator<Lender>
    {
        public LenderValidator()
        {
            RuleFor(t => t.Id).NotEmpty();
            RuleFor(t => t.CreateDate).NotEmpty();
            RuleFor(t => t.CompanyIcon).NotEmpty();
        }
    }
}
