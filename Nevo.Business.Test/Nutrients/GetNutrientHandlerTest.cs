using System;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Query;
using Coded.Core.Testing;
using Moq;
using Nevo.Business.Nutrients;
using Nevo.Contract.V1.Nutrients;
using Nevo.Data;
using Nevo.Data.Nutrients;
using Nevo.Test.Shared;
using Xunit;

namespace Nevo.Business.Test.Nutrients
{
    public class GetNutrientHandlerTest
    {
        private readonly GetNutrientHandler _handler;
        private readonly Mock<IQuery<SelectOne<Nutrient, string>, Nutrient>> _nutrientQuery;

        public GetNutrientHandlerTest()
        {
            _nutrientQuery = new();
            _handler = new(_nutrientQuery.Object);
        }

        [Fact(DisplayName = "Handle returns correct response.")]
        public async Task TestHandle()
        {
            // Arrange
            GetNutrientRequest request = new()
            {
                NutrientCode = "1234"
            };
            _nutrientQuery.SetupQuery(args => new()
            {
                Code = args.Id,
                NameEn = "NameEn",
                NameNl = "NameNl"
            });

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Verify.NotNull(response);
            Verify.NotNull(response.Nutrient);
            Assert.Equal("1234", response.Nutrient.Code);
            Assert.Equal("NameNl", response.Nutrient.NameNl);
            Assert.Equal("NameEn", response.Nutrient.NameEn);
        }

        [Fact(DisplayName = "Handle returns null when nutrient doesn't exist.")]
        public async Task Handle_ReturnsNull_WhenNoNutrient()
        {
            // Arrange
            GetNutrientRequest request = new()
            {
                NutrientCode = "1234"
            };
            _nutrientQuery.SetupQuery(_ => null);

            // Act
            var response = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.Null(response);
        }

        [Fact(DisplayName = "Handle throws when nutrient code is null.")]
        public async Task Handle_Throws_WhenNutrientCodeNull()
        {
            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(
                () => _handler.Handle(new(), CancellationToken.None));
        }
    }
}