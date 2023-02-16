using Coterie.Api.Controllers;
using Coterie.Api.Interfaces;
using Coterie.Api.Models.Requests;
using Coterie.Api.Services;
using Coterie.Api.Validators;
using FluentValidation;
using Moq;
using NUnit.Framework;

namespace Coterie.UnitTests.ControllerTests
{
    public class PremiumControllerTestsBase
    {
        protected PremiumController PremiumController;
        protected Mock<PremiumService> MockPremiumService;
        protected Mock<PremiumRequestValidator> MockValidator;
        

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            MockPremiumService = new Mock<PremiumService>();
            MockValidator = new Mock<PremiumRequestValidator>();
            PremiumController = new PremiumController(MockPremiumService.Object, MockValidator.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            MockPremiumService.Reset();
        }
    }
}