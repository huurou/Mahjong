namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class Daisharin : YakuBase
{
    public override int YakuId => 45;

    public override int TenhouId => -1;

    public override string Name => "Daisharin";

    public override string Japanese => "大車輪";

    public override string English => "Big wheels";

    public override int HanOpen { get; set; } = 0;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}