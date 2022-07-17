namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Renhou : YakuBase
{
    public override int YakuId => 9;
    public override int TenhouId => 36;
    public override string Name => "Renhou";
    public override string Japanese => "人和";
    public override string English => "Hand Of Man";
    public override int HanOpen { get; set; } = 0;
    public override int HanClosed { get; set; } = 5;
    public override bool IsYakuman => false;
}