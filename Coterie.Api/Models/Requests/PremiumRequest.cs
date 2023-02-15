using System.Collections.Generic;

namespace Coterie.Api.Models.Requests
{
    public class PremiumRequest
    {
        public BusinessType Business { get; set; }
        public List<string> States { get; set; }
        public int Revenue { get; set; }
    }
}