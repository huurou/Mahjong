namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Houtei : YakuBase
{
    public override int YakuId => 6;
    public override int TenhouId => 6;
    public override string Name => "Houtei Raoyui";
    public override string Japanese => "河底撈魚";
    public override string English => "Win by last discard";
    public override int HanOpen { get; set; } = 1;
    public override int HanClosed { get; set; } = 1;
    public override bool IsYakuman => false;
}