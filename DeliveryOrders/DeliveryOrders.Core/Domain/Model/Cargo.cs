using CSharpFunctionalExtensions;

namespace DeliveryOrders.Core.Domain.Model;

public sealed class Cargo : Entity
{
    private Cargo()
    {
    }

    private Cargo(long id, Dimensions dimensions, PackageType packageType, CargoType cargoType, string? comment) : base(id)
    {
        Dimensions = dimensions;
        PackageType = packageType;
        CargoType = cargoType;
        Comment = comment;
    }

    public Dimensions Dimensions { get; private set; }
    public PackageType PackageType { get; }
    public CargoType CargoType { get; }
    public string? Comment { get; set; }

    public static Result<Cargo> Create(long id, Dimensions dimensions, PackageType packageType, CargoType cargoType, string? comment)
    {
        if (id <= 0)
        {
            return Result.Failure<Cargo>("Недействительный id");
        }

        return new Cargo(id, dimensions, packageType, cargoType, comment);
    }
}
