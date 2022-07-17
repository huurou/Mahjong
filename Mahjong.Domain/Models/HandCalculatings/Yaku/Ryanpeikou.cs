namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Ryanpeikou : YakuBase
{
    public override int YakuId => 34;

    public override int TenhouId => 32;

    public override string Name => "Ryanpeikou";

    public override string Japanese => "二盃口";

    public override string English => "Two Sets Of Identical Sequences";

    public override int HanOpen { get; set; } = 0;

    public override int HanClosed { get; set; } = 3;

    public override bool IsYakuman => false;
}