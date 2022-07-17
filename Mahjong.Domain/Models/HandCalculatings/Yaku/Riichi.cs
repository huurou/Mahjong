namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Riichi : YakuBase
{
    public override int YakuId => 1;
    public override int TenhouId => 1;
    public override string Name => "Riichi";
    public override string Japanese => "立直";
    public override string English => "Riichi";
    public override int HanOpen { get; set; } = 0;
    public override int HanClosed { get; set; } = 1;
    public override bool IsYakuman => false;
}