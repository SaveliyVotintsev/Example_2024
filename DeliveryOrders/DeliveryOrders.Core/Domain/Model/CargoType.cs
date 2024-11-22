using Ardalis.SmartEnum;

namespace DeliveryOrders.Core.Domain.Model;

public sealed class CargoType : SmartEnum<CargoType>
{
    public static readonly CargoType General = new("Общий", 1);
    public static readonly CargoType Fragile = new("Хрупкий", 2);
    public static readonly CargoType Toxic = new("Ядовитый", 3);

    private CargoType(string name, int value) : base(name, value)
    {
    }
}
