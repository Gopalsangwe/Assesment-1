using AvalphaTechnologies.CommissionCalculator.Tests;
using System;
using AvalphaTechnologies.CommissionCalculator.BusinessLogic;
using Xunit;

namespace AvalphaTechnologies.CommissionCalculator.Tests
{
    public class CommissionCalculatorTests
    {
        private readonly AvalphaTechnologies.CommissionCalculator.BusinessLogic.CommissionCalculator _calculator
      = new AvalphaTechnologies.CommissionCalculator.BusinessLogic.CommissionCalculator();
        [Fact]
        public void Calculate_ReturnsExpectedValues_ForSampleInput()
        {
            // Arrange
            var local = 10;
            var foreign = 10;
            var avg = 100m;

            // Act
            var result = _calculator.Calculate(local, foreign, avg);

            // Assert
            Assert.Equal(200m, result.AvalphaLocal);
            Assert.Equal(350m, result.AvalphaForeign);
            Assert.Equal(550m, result.AvalphaTotal);

            Assert.Equal(20m, result.CompetitorLocal);
            Assert.Equal(75.5m, result.CompetitorForeign);
            Assert.Equal(95.5m, result.CompetitorTotal);
        }

        [Fact]
        public void Calculate_ReturnsZeros_WhenAllInputsAreZero()
        {
            var result = _calculator.Calculate(0, 0, 0m);

            Assert.Equal(0m, result.AvalphaLocal);
            Assert.Equal(0m, result.AvalphaForeign);
            Assert.Equal(0m, result.AvalphaTotal);

            Assert.Equal(0m, result.CompetitorLocal);
            Assert.Equal(0m, result.CompetitorForeign);
            Assert.Equal(0m, result.CompetitorTotal);
        }

        [Theory]
        [InlineData(-1, 0, 10)]
        [InlineData(0, -1, 10)]
        [InlineData(0, 0, -10)]
        public void Calculate_ThrowsArgumentException_ForNegativeInputs(int local, int foreign, decimal avg)
        {
            Assert.Throws<ArgumentException>(() => _calculator.Calculate(local, foreign, avg));
        }
    }
}