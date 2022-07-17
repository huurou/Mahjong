namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Tanyao : YakuBase
{
    public override int YakuId => 11;
    public override int TenhouId => 8;
    public override string Name => "Tanyao";
    public override string Japanese => "断幺九";
    public override string English => "All Simples";
    public override int HanOpen { get; set; } = 1;
    public override int HanClosed { get; set; } = 1;
    public override bool IsYakuman => false;
}