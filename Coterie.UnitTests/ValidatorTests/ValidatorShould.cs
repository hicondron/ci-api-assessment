using System.Collections.Generic;
using Coterie.Api.Models;
using Coterie.Api.Models.Requests;
using NUnit.Framework;
using FluentValidation.TestHelper;

namespace Coterie.UnitTests.ValidatorTests
{
    public class ValidatorShould : ValidatorTestsBase
    {
        [Test]
        public void Revenue_WhenValueIsZero_ReturnsValidationError()
        {
            // Arrange
            var request = new PremiumRequest { Revenue = 0, Business = BusinessType.Plumber, States = new List<string>() { "TX" } };
            
            // Act & Assert
            PremiumRequestValidator.TestValidate(request)
                .ShouldHaveValidationErrorFor(x => x.Revenue);
        }
        
        [Test]
        public void States_WhenValueIsNull_ReturnsValidationError()
        {
            // Arrange
            var request = new PremiumRequest { Revenue = 5000000, Business = BusinessType.Plumber, States = null };

            // Act & Assert
            PremiumRequestValidator.TestValidate(request)
                .ShouldHaveValidationErrorFor(x => x.States);
        }

        [Test]
        public void States_WhenValueIsEmpty_ReturnsValidationError()
        {
            // Arrange
            var request = new PremiumRequest { Revenue = 5000000, Business = BusinessType.Plumber, States = new List<string>() };

            // Act & Assert
            PremiumRequestValidator.TestValidate(request)
                .ShouldHaveValidationErrorFor(x => x.States);
        }

        [Test]
        public void PremiumRequest_WhenValuesAreValid_ReturnsNoValidationErrors()
        {
            // Arrange
            var request = new PremiumRequest { Revenue = 5000000, Business = BusinessType.Plumber, States = new List<string>() { "TX", "OH" } };

            // Act & Assert
            PremiumRequestValidator.TestValidate(request)
                .ShouldNotHaveValidationErrorFor(x => x.Revenue);
            PremiumRequestValidator.TestValidate(request)
                .ShouldNotHaveValidationErrorFor(x => x.Business);
            PremiumRequestValidator.TestValidate(request)
                .ShouldNotHaveValidationErrorFor(x => x.States);
        }
    }
}