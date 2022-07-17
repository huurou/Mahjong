namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Pinfu : YakuBase
{
    public override int YakuId => 10;
    public override int TenhouId => 7;
    public override string Name => "Pinfu";
    public override string Japanese => "平和";
    public override string English => "All Sequences";
    public override int HanOpen { get; set; } = 0;
    public override int HanClosed { get; set; } = 1;
    public override bool IsYakuman => false;
}