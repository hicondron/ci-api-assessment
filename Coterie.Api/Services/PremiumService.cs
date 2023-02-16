using System;
using System.Linq;
using Coterie.Api.Interfaces;
using Coterie.Api.Models;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;

namespace Coterie.Api.Services
{
    public class PremiumService : IPremiumService
    {
        private const int HazardFactor = 4;
        public PremiumResponse CalculatePremium(PremiumRequest request)
        {
            var basePremium = (int)Math.Ceiling(request.Revenue / 1000.0);

            var premiums = (from state in request.States
                select GetStateAbbreviation(state)
                into stateNameAbbreviated
                let stateFactor = GetStateFactor(stateNameAbbreviated)
                let businessFactor = GetBusinessFactor(request.Business)
                let premium = basePremium * HazardFactor * stateFactor * businessFactor
                select new Premiums { State = stateNameAbbreviated, Premium = premium }).ToList();

            return new PremiumResponse
            {
                Business = request.Business,
                Revenue = request.Revenue,
                Premiums = premiums
                
            };
        }

        public State GetStateAbbreviation(string state)
        {
            state = state.ToUpperInvariant(); // Ignore case by converting to uppercase
            switch (state)
            {
                case "TEXAS":
                case "TX":
                    return State.TX;
                case "FLORIDA":
                case "FL":
                    return State.FL;
                case "OHIO":
                case "OH":
                    return State.OH;
                default:
                    throw new ArgumentException("Invalid state name or abbreviation.");
            }
        }
        
        private static double GetStateFactor(State state)
        {
            return state switch
            {
                State.FL => 1.2,
                State.OH => 1,
                State.TX => .943,
                _ => throw new ArgumentException("Invalid state")
            };
        }

        private static double GetBusinessFactor(BusinessType businessType)
        {
            return businessType switch
            {
                BusinessType.Architect => 1,
                BusinessType.Plumber => .5,
                BusinessType.Programmer => 1.25,
                _ => throw new ArgumentException("Invalid business type")
            };
        }
    }
}