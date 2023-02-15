using System.Collections.Generic;
using Coterie.Api.Models.Requests;
using Microsoft.AspNetCore.Routing.Matching;

namespace Coterie.Api.Models.Responses
{
    public class PremiumResponse
    {
     public BusinessType Business { get; set; }
     public int Revenue { get; set; }
     public List<Premiums> Premiums { get; set; }
    }
}