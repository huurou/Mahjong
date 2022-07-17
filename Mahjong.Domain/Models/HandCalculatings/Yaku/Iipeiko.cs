namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Iipeiko : YakuBase
{
    public override int YakuId => 12;

    public override int TenhouId => 9;

    public override string Name => "Iipeiko";

    public override string Japanese => "一盃口";

    public override string English => "Identical Sequences";

    public override int HanOpen { get; set; } = 0;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}