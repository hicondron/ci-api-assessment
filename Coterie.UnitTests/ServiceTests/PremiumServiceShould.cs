using System;
using System.Collections.Generic;
using Coterie.Api.Models;
using Coterie.Api.Models.Requests;
using NUnit.Framework;

namespace Coterie.UnitTests.ServiceTests
{
    public class PremiumServiceTestsShould : PremiumServiceTestsBase
    {

        [Test]
        public void CalculatePremium_WithValidRequest_ReturnsValidResponse()
        {
            // Arrange
            var request = new PremiumRequest
            {
                Business = BusinessType.Plumber,
                Revenue = 6000000,
                States = new List<string> { "TX", "OHIO", "FLoRIdA" }
            };

            // Act
            var response = PremiumService.CalculatePremium(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(request.Business, response.Business);
            Assert.AreEqual(request.Revenue, response.Revenue);
            Assert.AreEqual(3, response.Premiums.Count);
        }

        [Test]
        public void CalculatePremium_WithInvalidState_ThrowsArgumentException()
        {
            // Arrange
            var request = new PremiumRequest
            {
                Business = BusinessType.Architect,
                Revenue = 5000000,
                States = new List<string> { "TX", "MA" }
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => PremiumService.CalculatePremium(request));
        }

        [Test]
        public void GetStateAbbreviation_WithValidState_ReturnsCorrectAbbreviation()
        {
            // Arrange & Act
            var abbreviation = PremiumService.GetStateAbbreviation("Florida");

            // Assert
            Assert.AreEqual(State.FL, abbreviation);
        }

        [Test]
        public void GetStateAbbreviation_WithInvalidState_ThrowsArgumentException()
        {
            // Arrange & Act & Assert
            Assert.Throws<ArgumentException>(() => PremiumService.GetStateAbbreviation("Massachusetts"));
        }
    }
}
