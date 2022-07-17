namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class KokushiMusou : YakuBase
{
    public override int YakuId => 36;

    public override int TenhouId => 47;

    public override string Name => "KokushiMusou";

    public override string Japanese => "国士無双";

    public override string English => "Thirteen Orphans";

    public override int HanOpen { get; set; } = 0;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}