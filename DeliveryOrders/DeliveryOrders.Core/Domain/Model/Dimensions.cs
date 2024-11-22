using CSharpFunctionalExtensions;

namespace DeliveryOrders.Core.Domain.Model;

public sealed class Dimensions : ValueObject
{
    private Dimensions()
    {
    }

    private Dimensions(decimal length, decimal width, decimal height, decimal weight)
    {
        Length = length;
        Width = width;
        Height = height;
        Weight = weight;

        Volume = length * width * height;
    }

    public decimal Length { get; }
    public decimal Width { get; }
    public decimal Height { get; }
    public decimal Weight { get; }
    public decimal Volume { get; }

    public static Result<Dimensions> Create(decimal length, decimal width, decimal height, decimal weight)
    {
        if (length is < 0 or > 2)
        {
            return Result.Failure<Dimensions>("Длина должна быть от 0 до 2.");
        }

        if (width is < 0 or > 2)
        {
            return Result.Failure<Dimensions>("Ширина должна быть от 0 до 2.");
        }

        if (height is < 0 or > 2)
        {
            return Result.Failure<Dimensions>("Высота должна быть от 0 до 2.");
        }

        if (weight is < 0 or > 100)
        {
            return Result.Failure<Dimensions>("Вес должен быть от 0 до 100.");
        }

        return new Dimensions(length, width, height, weight);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Length;
        yield return Width;
        yield return Height;
        yield return Weight;
    }
}
