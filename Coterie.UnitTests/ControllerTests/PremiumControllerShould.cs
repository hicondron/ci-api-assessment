using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Coterie.Api.Controllers;
using Coterie.Api.Interfaces;
using Coterie.Api.Models;
using Coterie.Api.Models.Requests;
using Coterie.Api.Models.Responses;
using Coterie.UnitTests.ServiceTests;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Coterie.UnitTests.ControllerTests
{
    [TestFixture]
    public class PremiumControllerShould : PremiumServiceTestsBase
    {
        [Test]
        public async Task PostPremium_ReturnsOkResult_WithPremiumResponse()
        {
            // Arrange
            var premiumRequest = new PremiumRequest { Business = BusinessType.Programmer, Revenue = 150000, States = new List<string>{"FL"}};
            var premiumResponse = new PremiumResponse
                { Business = BusinessType.Programmer, Revenue = 150000, Premiums = new List<Premiums>() };
            var premiumServiceMock = new Mock<IPremiumService>();
            var validatorMock = new Mock<IValidator<PremiumRequest>>();
            premiumServiceMock.Setup(service => service.CalculatePremium(premiumRequest)).Returns(premiumResponse);
            validatorMock.Setup(validator => validator.ValidateAsync(premiumRequest, It.IsAny<CancellationToken>())).ReturnsAsync(new ValidationResult());
            var premiumController = new PremiumController(premiumServiceMock.Object, validatorMock.Object );

            // Act
            var result = await premiumController.PostPremium(premiumRequest);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task PostPremium_ReturnsBadRequestResult_WhenPremiumRequestIsNull()
        {
            // Arrange
            var premiumServiceMock = new Mock<IPremiumService>();
            var validatorMock = new Mock<IValidator<PremiumRequest>>();
            var premiumController = new PremiumController(premiumServiceMock.Object, validatorMock.Object);

            // Act
            var result = await premiumController.PostPremium(null);

            // Assert
            Assert.IsInstanceOf<BadRequestResult>(result.Result);
        }
    }
}