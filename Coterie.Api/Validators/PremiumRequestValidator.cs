using System;
using System.Linq;
using Coterie.Api.Models;
using Coterie.Api.Models.Requests;
using FluentValidation;

namespace Coterie.Api.Validators
{
    public class PremiumRequestValidator : AbstractValidator<PremiumRequest>
    {
        public PremiumRequestValidator()
        {

            RuleFor(x => x.Revenue).GreaterThan(0)
                .WithMessage("Please enter a valid revenue amount.  The amount must be a positive number.");
            RuleFor(x => x.States)
                .NotNull()
                .NotEmpty()
                .Must(x => x == null || x.All(IsValidStateNameOrAbbreviation))
                .WithMessage("One or more states in the list are invalid or do not match any value in the State enum.");

        }
      
        private bool IsValidStateNameOrAbbreviation(string state)
        {
            state = state.ToUpperInvariant();
            switch (state)
            {
                case "TEXAS":
                case "TX":
                case "FLORIDA":
                case "FL":
                case "OHIO":
                case "OH":
                    return true;
                default:
                    return false;
            }
        }
    }
}