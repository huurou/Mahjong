namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class SanKantsu : YakuBase
{
    public override int YakuId => 28;

    public override int TenhouId => 27;

    public override string Name => "SanKantsu";

    public override string Japanese => "三槓子";

    public override string English => "Three Kans";

    public override int HanOpen { get; set; } = 2;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}