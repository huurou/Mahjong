namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class Shousuushii : YakuBase
{
    public override int YakuId => 40;

    public override int TenhouId => 50;

    public override string Name => "Shousuushii";

    public override string Japanese => "小四喜";

    public override string English => "Small Four Winds";

    public override int HanOpen { get; set; } = 13;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}