namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Chankan : YakuBase
{
    public override int YakuId => 3;
    public override int TenhouId => 3;
    public override string Name => "Chankan";
    public override string Japanese => "搶槓";
    public override string English => "Robbing A Kan";
    public override int HanOpen { get; set; } = 1;
    public override int HanClosed { get; set; } = 1;
    public override bool IsYakuman => false;
}