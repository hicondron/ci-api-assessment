using System.Data;
using System.Drawing;
using Coterie.Api.Models.Requests;
using FluentValidation;

namespace Coterie.Api.Validators
{
    public class PremiumRequestValidator : AbstractValidator<PremiumRequest>
    {
        public PremiumRequestValidator()
        {
            RuleFor(x => x.Revenue).GreaterThan(0)
                .WithMessage("Please enter a valid revenue amount");
            RuleFor(x => x.Business).IsInEnum()
                .WithMessage("Please enter a valid business type");
            RuleFor(x => x.States).NotNull()
                .WithMessage("Please enter valid states");
        }
    }
}