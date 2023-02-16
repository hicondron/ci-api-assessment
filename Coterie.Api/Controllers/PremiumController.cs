using System.Threading.Tasks;
using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coterie.Api.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class PremiumController : ControllerBase
        {
        private readonly IPremiumService _premiumService;
        private readonly IValidator<PremiumRequest> _validator;
        public PremiumController(IPremiumService premiumService, IValidator<PremiumRequest> validator)
        {
            _premiumService = premiumService;
            _validator = validator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PremiumResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PremiumResponse>> PostPremium(PremiumRequest request)
        {
            if (request is null) return BadRequest();
            var result = await _validator.ValidateAsync(request);
            
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            return Ok(_premiumService.CalculatePremium(request));
        }
    }
}