using CSharpFunctionalExtensions;

namespace DeliveryOrders.Core.Domain.Model;

public sealed class Cargo : Entity
{
    private Cargo()
    {
    }

    private Cargo(long id, Dimensions dimensions, string packageType, string cargoType, string? comment) : base(id)
    {
        Dimensions = dimensions;
        PackageType = packageType;
        CargoType = cargoType;
        Comment = comment;
    }

    public Dimensions Dimensions { get; private set; }
    public string PackageType { get; }
    public string CargoType { get; }
    public string? Comment { get; set; }

    public static Result<Cargo> Create(long id, Dimensions dimensions, string packageType, string cargoType, string? comment)
    {
        if (id <= 0)
        {
            return Result.Failure<Cargo>("Недействительный id");
        }

        if (string.IsNullOrWhiteSpace(packageType))
        {
            return Result.Failure<Cargo>("Некорректный тип упаковки");
        }

        if (string.IsNullOrWhiteSpace(cargoType))
        {
            return Result.Failure<Cargo>("Некорректный тип места");
        }

        return new Cargo(id, dimensions, packageType, cargoType, comment);
    }
}
