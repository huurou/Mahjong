namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class Daisangen : YakuBase
{
    public override int YakuId => 39;

    public override int TenhouId => 39;

    public override string Name => "Daisangen";

    public override string Japanese => "大三元";

    public override string English => "Big Three Dragons";

    public override int HanOpen { get; set; } = 13;
    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}