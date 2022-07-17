namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Shosangen : YakuBase
{
    public override int YakuId => 31;

    public override int TenhouId => 30;

    public override string Name => "Shosangen";

    public override string Japanese => "小三元";

    public override string English => "Small Three Dragons";

    public override int HanOpen { get; set; } = 2;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}