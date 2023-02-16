using Coterie.Api.Interfaces;
using Coterie.Api.Services;
using NUnit.Framework;

namespace Coterie.UnitTests.ServiceTests
{
    public class PremiumServiceTestsBase
    {
        protected IPremiumService PremiumService;

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            PremiumService = new PremiumService();
        }

        [TearDown]
        public void Cleanup()
        {
            
        }
    }
}