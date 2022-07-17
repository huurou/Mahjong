namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Ittsu : YakuBase
{
    public override int YakuId => 23;

    public override int TenhouId => 24;

    public override string Name => "Ittsu";

    public override string Japanese => "一気通貫";

    public override string English => "Straight";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}