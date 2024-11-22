using CSharpFunctionalExtensions;
using DeliveryOrders.Core.Domain.Model;
using FluentAssertions.Execution;

namespace DeliveryOrders.UnitTests.Domain.Models;

public class DimensionsShould
{
    [Theory]
    [InlineData(1, 1, 1, 1)]
    [InlineData(2, 2, 2, 100)]
    [InlineData(1.5, 1.5, 1.5, 50)]
    public void CreateDimensions_WhenValidParametersAreProvided(decimal length, decimal width, decimal height, decimal weight)
    {
        Result<Dimensions> actual = Dimensions.Create(length, width, height, weight);

        actual.IsSuccess.Should().BeTrue();

        Dimensions actualValue = actual.Value;

        using (new AssertionScope())
        {
            actualValue.Length.Should().Be(length);
            actualValue.Width.Should().Be(width);
            actualValue.Height.Should().Be(height);
            actualValue.Weight.Should().Be(weight);
        }
    }

    [Theory]
    [InlineData(-5, 1, 1, 1)]
    [InlineData(2, 40, 2, 100)]
    [InlineData(1.5, 1.5, -55, 50)]
    [InlineData(1.5, 1.5, 1.5, 210)]
    public void NotCreateDimensions_WhenInvalidParametersAreProvided(decimal length, decimal width, decimal height, decimal weight)
    {
        Result<Dimensions> actual = Dimensions.Create(length, width, height, weight);

        actual.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void CalculateCorrectVolume_WhenDimensionsAreCreated()
    {
        Result<Dimensions> actual = Dimensions.Create(1, 2, 2, 5);

        actual.Value.Volume.Should().Be(4);
    }

    [Fact]
    public void BeEqual_WhenComparingIdenticalDimensions()
    {
        Result<Dimensions> first = Dimensions.Create(1, 2, 2, 5);
        Result<Dimensions> second = Dimensions.Create(1, 2, 2, 5);

        using (new AssertionScope())
        {
            (first.Value == second.Value).Should().BeTrue();
            first.Value.Equals(second.Value).Should().BeTrue();

            (second.Value == first.Value).Should().BeTrue();
            second.Value.Equals(first.Value).Should().BeTrue();
        }
    }

    [Fact]
    public void BeNotEqual_WhenComparingDifferentDimensions()
    {
        Result<Dimensions> first = Dimensions.Create(1, 2, 2, 5);
        Result<Dimensions> third = Dimensions.Create(1, 2, 1, 5);

        using (new AssertionScope())
        {
            (first.Value == third.Value).Should().BeFalse();
            first.Value.Equals(third.Value).Should().BeFalse();

            (third.Value == first.Value).Should().BeFalse();
            third.Value.Equals(first.Value).Should().BeFalse();
        }
    }
}
