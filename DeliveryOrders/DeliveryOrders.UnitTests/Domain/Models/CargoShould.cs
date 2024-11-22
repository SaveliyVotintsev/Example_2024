using DeliveryOrders.Core.Domain.Model;

namespace DeliveryOrders.UnitTests.Domain.Models;

public class CargoShould
{
    [Fact]
    public void BeEqualToCargo_WhenIdsEquals()
    {
        Dimensions dimensions = Dimensions.Create(1, 2, 2, 5).Value;

        Cargo first = Cargo.Create(1, dimensions, "Коробка", "Хрупкий", null).Value;
        Cargo second = Cargo.Create(1, dimensions, "Пакет", "Ядовитый", null).Value;

        first.Equals(second).Should().BeTrue();
    }

    [Fact]
    public void BeEqualToCargo_WhenIdsNotEquals()
    {
        Dimensions dimensions = Dimensions.Create(1, 2, 2, 5).Value;

        Cargo first = Cargo.Create(1, dimensions, "Пакет", "Ядовитый", null).Value;
        Cargo second = Cargo.Create(2, dimensions, "Пакет", "Ядовитый", null).Value;

        first.Equals(second).Should().BeFalse();
    }
}
