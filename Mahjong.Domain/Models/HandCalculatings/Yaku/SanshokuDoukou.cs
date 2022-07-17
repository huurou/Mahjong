namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class SanshokuDoukou : YakuBase
{
    public override int YakuId => 29;

    public override int TenhouId => 26;

    public override string Name => "SanshokuDoukou";

    public override string Japanese => "三色同刻";

    public override string English => "Three Colored Triplets";

    public override int HanOpen { get; set; } = 2;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}