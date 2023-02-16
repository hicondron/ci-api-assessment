using Coterie.Api.Interfaces;
using Coterie.Api.Validators;
using NUnit.Framework;

namespace Coterie.UnitTests.ValidatorTests
{
    [TestFixture]
    public class ValidatorTestsBase
    {
        protected PremiumRequestValidator PremiumRequestValidator;

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            PremiumRequestValidator = new PremiumRequestValidator();
        }

        [TearDown]
        public void Cleanup()
        {
        }
    }
}