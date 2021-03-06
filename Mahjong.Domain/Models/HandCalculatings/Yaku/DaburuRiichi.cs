namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class DaburuRiichi : YakuBase
{
    public override int YakuId => 7;
    public override int TenhouId => 21;
    public override string Name => "Double Riichi";
    public override string Japanese => "ダブル立直";
    public override string English => "Double Riichi";
    public override int HanOpen { get; set; } = 0;
    public override int HanClosed { get; set; } = 2;
    public override bool IsYakuman => false;
}