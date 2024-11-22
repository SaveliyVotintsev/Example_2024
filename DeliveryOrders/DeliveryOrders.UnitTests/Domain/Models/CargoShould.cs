using CSharpFunctionalExtensions;
using DeliveryOrders.Core.Domain.Model;
using FluentAssertions.Execution;

namespace DeliveryOrders.UnitTests.Domain.Models;

public class CargoShould
{
    [Theory]
    [InlineData(1, 1, 2, "Test comment")]
    [InlineData(2, 2, 3, null)]
    [InlineData(3, 1, 1, "")]
    public void CreateCargo_WhenValidParametersAreProvided(long id, int packageTypeValue, int cargoTypeValue, string? comment)
    {
        Dimensions dimensions = Dimensions.Create(1, 2, 2, 5).Value;
        PackageType packageType = PackageType.FromValue(packageTypeValue);
        CargoType cargoType = CargoType.FromValue(cargoTypeValue);

        Result<Cargo> result = Cargo.Create(id, dimensions, packageType, cargoType, comment);
        result.IsSuccess.Should().BeTrue();

        using (new AssertionScope())
        {
            result.Value.Id.Should().Be(id);
            result.Value.Dimensions.Should().Be(dimensions);
            result.Value.PackageType.Should().Be(packageType);
            result.Value.CargoType.Should().Be(cargoType);
            result.Value.Comment.Should().Be(comment);
        }
    }

    [Theory]
    [InlineData(0, 1, 2, "Test comment")]
    [InlineData(-1, 2, 3, null)]
    public void FailToCreateCargo_WhenInvalidParametersAreProvided(long id, int packageTypeValue, int cargoTypeValue, string? comment)
    {
        Dimensions dimensions = Dimensions.Create(1, 2, 2, 5).Value;
        PackageType packageType = PackageType.FromValue(packageTypeValue);
        CargoType cargoType = CargoType.FromValue(cargoTypeValue);

        Result<Cargo> result = Cargo.Create(id, dimensions, packageType, cargoType, comment);

        result.IsFailure.Should().BeTrue();
    }

    [Fact]
    public void BeEqual_WhenComparingIdenticalId()
    {
        Dimensions dimensions = Dimensions.Create(1, 2, 2, 5).Value;

        Cargo first = Cargo.Create(1, dimensions, PackageType.Box, CargoType.Fragile, null).Value;
        Cargo second = Cargo.Create(1, dimensions, PackageType.Bag, CargoType.Toxic, null).Value;

        using (new AssertionScope())
        {
            (first == second).Should().BeTrue();
            first.Equals(second).Should().BeTrue();

            (second == first).Should().BeTrue();
            second.Equals(first).Should().BeTrue();
        }
    }

    [Fact]
    public void BeNotEqual_WhenComparingDifferentId()
    {
        Dimensions dimensions = Dimensions.Create(1, 2, 2, 5).Value;

        Cargo first = Cargo.Create(1, dimensions, PackageType.Bag, CargoType.Toxic, null).Value;
        Cargo second = Cargo.Create(2, dimensions, PackageType.Bag, CargoType.Toxic, null).Value;

        using (new AssertionScope())
        {
            (first == second).Should().BeFalse();
            first.Equals(second).Should().BeFalse();

            (second == first).Should().BeFalse();
            second.Equals(first).Should().BeFalse();
        }
    }
}
