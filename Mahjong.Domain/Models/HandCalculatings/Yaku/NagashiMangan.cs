namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class NagashiMangan : YakuBase
{
    public override int YakuId => 8;
    public override int TenhouId => -1;
    public override string Name => "Nagashi Mangan";
    public override string Japanese => "流し満貫";
    public override string English => "Nagashi Mangan";
    public override int HanOpen { get; set; } = 5;
    public override int HanClosed { get; set; } = 5;
    public override bool IsYakuman => false;
}