using System.Threading.Tasks;
using Coterie.Api.Models;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;

namespace Coterie.Api.Interfaces
{
    public interface IPremiumService
    {
        PremiumResponse CalculatePremium(PremiumRequest request);
        State GetStateAbbreviation(string state);
    }
}