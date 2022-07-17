namespace Mahjong.Domain.Models.HandCalculatings;

internal class FuDetail : ValueObject<FuDetail>
{
    public FuReason Reason { get; }
    public int Fu { get; }

    public FuDetail(FuReason reason)
        : this(reason, reason switch
        {
            FuReason.Base => 20,
            FuReason.HandWithoutHu => 2,
            FuReason.Tsumo => 2,
            FuReason.MenzenRon => 10,
            FuReason.Penchan => 2,
            FuReason.Kanchan => 2,
            FuReason.PairWait => 2,
            FuReason.ValuedPair => 2,
            FuReason.OpenPon => 2,
            FuReason.ClosedPon => 4,
            FuReason.OpenYaochuPon => 4,
            FuReason.ClosedYaochuPon => 8,
            FuReason.OpenKan => 8,
            FuReason.ClosedKan => 16,
            FuReason.OpenYaochuKan => 16,
            FuReason.ClosedYaochuKan => 32,
            FuReason.None or _ => 0,
        })
    { }

    public FuDetail(FuReason reason, int fu)
    {
        Reason = reason;
        Fu = fu;
    }

    public override bool Equals(ValueObject<FuDetail>? other)
    {
        return other is FuDetail fuDetail
            && Reason == fuDetail.Reason && Fu == fuDetail.Fu;
    }

    public override int GetHashCodeCore()
    {
        return new { Reason, Fu }.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Reason} {Fu,2}";
    }
}