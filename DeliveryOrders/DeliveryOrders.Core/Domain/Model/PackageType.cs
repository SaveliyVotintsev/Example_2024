using Ardalis.SmartEnum;

namespace DeliveryOrders.Core.Domain.Model;

public sealed class PackageType : SmartEnum<PackageType>
{
    public static readonly PackageType Box = new("Коробка", 1);
    public static readonly PackageType Bag = new("Пакет", 2);

    private PackageType(string name, int value) : base(name, value)
    {
    }
}
