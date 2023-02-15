using System.Threading.Tasks;
using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Coterie.Api.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class PremiumController : ControllerBase
    {
        private readonly IPremiumService _premiumService;

        public PremiumController(IPremiumService premiumService)
        {
            _premiumService = premiumService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PremiumResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PremiumResponse> PostPremium([FromBody] PremiumRequest request)
        {
            return Ok(_premiumService.CalculatePremium(request));
        }
    }
}