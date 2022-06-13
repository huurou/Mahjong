namespace Mahjong.Domain.Models.HandCalculatings;

public class FuResult : ValueObject<FuResult>
{
    public IEnumerable<FuDetail> Details { get; } = new List<FuDetail>();
    public int Total { get; }

    public FuResult(FuDetail detail)
    {
        Details = new[] { detail };
        Total = detail.Fu;
    }

    public FuResult(IEnumerable<FuReason> reasons)
    {
        Details = reasons.Select(x => new FuDetail(x));
        Total = (Details.Sum(x => x.Fu) + 9) / 10 * 10;
    }

    public override bool Equals(ValueObject<FuResult>? other)
    {
        return other is FuResult result &&
            Details.SequenceEqual(result.Details) && Total == result.Total;
    }

    public override int GetHashCodeCore()
    {
        return new { Details, Total }.GetHashCode();
    }
}